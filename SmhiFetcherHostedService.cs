using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Linq;
using System;

namespace HelloWorldServer
{

    public class WeatherRepository : IWeatherRepository
    {

        private  static MyWeatherData WeatherData;
        public MyWeatherData Get()
        {
            return WeatherData;
        }

        public void Save(MyWeatherData data)
        {
            WeatherData = data;
        }
    }
    public interface IWeatherRepository {
         void Save(MyWeatherData data);
         MyWeatherData Get();
    }
    public class SmhiFetcherHostedService : IHostedService
{

public SmhiFetcherHostedService(IWeatherRepository weatherRepository) {
            this.weatherRepository = weatherRepository;
        }
    private Timer _timer;
        private readonly IWeatherRepository weatherRepository;

        public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(CallSmhi, null, 0, 15 * 60 * 1000);
        return Task.CompletedTask;
    }
    void CallSmhi(object state)
    {
       var client = new System.Net.Http.HttpClient();

           var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Smhi));
           var streamTask = client.
           GetStreamAsync("https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/17.9490/lat/59.382/data.json");
           
            var result = serializer.ReadObject(streamTask.Result) as Smhi;
           
            weatherRepository.Save( 
            new MyWeatherData() {
                Updated = DateTime.Now,
                WeatherData = result.timeSeries.OrderBy(x => x.validTime).Take(24).
            Select(x => 
            new MyWeather { 
                Hour = x.Hour,
                Temperature = x.Temperature,
                Rain = x.Rain
            }).ToList()});
    }
 
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
}
}
