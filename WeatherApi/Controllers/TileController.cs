using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WeatherApi.Controllers
{
    public class TileController : Controller
    {
        // GET: Tile
        public async Task<ActionResult> Index(string result, int offset)
        {
            switch (result)
            {
                case "Moscow":
                    result = "524901";
                    break;
                default:
                    result = "524901";
                    break;
            }

            var weather = await Models.OWM_City_Forecast_Facade.GetWeatherCityForecast(result);
            var sunrise = (UnixTimestampToDateTime(weather.sys.sunrise)).AddHours(offset).ToShortTimeString();
            var sunset = (UnixTimestampToDateTime(weather.sys.sunset)).AddHours(offset).ToShortTimeString();

            ViewBag.Temp1 = ((int)weather.main.temp).ToString();
            ViewBag.Descr1 = weather.weather[0].description;
            ViewBag.Sunrise = sunrise;
            ViewBag.Sunset = sunset;

            return View();
        }

        public static DateTime UnixTimestampToDateTime(double unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks);
        }
    }
}