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
}
