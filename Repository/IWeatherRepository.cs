namespace HelloWorldServer
{
    public interface IWeatherRepository {
         void Save(MyWeatherData data);
         MyWeatherData Get();
    }
}
