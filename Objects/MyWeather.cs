using System;
using System.Collections.Generic;

namespace HelloWorldServer
{
    
public class MyWeatherData {
   // public DateTime Updated {get;set;}
    //public string Test => "Cloud connect test";
    public List<MyWeather> WeatherData {get;set;}

}

        public class MyWeather {
            public int Hour {get;set;}
            public decimal? Temperature {get;set;}
            public decimal? Rain {get;set;}
        }


       
    
}
