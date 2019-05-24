using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository weatherRepo;

        public WeatherController(IWeatherRepository weatherRepo)
        {
            this.weatherRepo = weatherRepo;
        }

        // GET api/values
        [HttpGet]
         public MyWeatherData Get()
        {
           return weatherRepo.Get();
           
        }
    }
}
