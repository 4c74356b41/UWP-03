using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WeatherApi.Controllers
{
    public class HomeController : Controller
    {
        private decimal latitude;
        private decimal longitude;

        // GET: Home
        public async Task<ActionResult> Index(string lat, string lon)
        {
            decimal.TryParse(lat.Substring(0, 5), NumberStyles.Any, CultureInfo.InvariantCulture, out latitude);
            decimal.TryParse(lon.Substring(0, 5), NumberStyles.Any, CultureInfo.InvariantCulture, out longitude);

            if ((latitude >= 55.55m & latitude <= 55.95m) & (longitude >= 37.35m & longitude <= 37.85m))
            {
                latitude = 55.75222m;
                longitude = 37.615555m;
            }

            var weather = await Models.OWM_Forecast_Facade.GetWeatherForecast(latitude, longitude);

            ViewBag.Name = weather.city.name;
            ViewBag.Time = weather.list[0].dt_txt;

            ViewBag.Temp1 = ((int)weather.list[0].main.temp).ToString();
            ViewBag.Temp2 = ((int)weather.list[7].main.temp).ToString();
            ViewBag.Temp3 = ((int)weather.list[15].main.temp).ToString();
            ViewBag.Temp4 = ((int)weather.list[23].main.temp).ToString();
            ViewBag.Temp5 = ((int)weather.list[31].main.temp).ToString();

            ViewBag.Descr1 = weather.list[0].weather[0].description;
            ViewBag.Descr2 = weather.list[7].weather[0].description;
            ViewBag.Descr3 = weather.list[15].weather[0].description;
            ViewBag.Descr4 = weather.list[23].weather[0].description;
            ViewBag.Descr5 = weather.list[31].weather[0].description;

            ViewBag.Icon1 = weather.list[0].weather[0].icon;
            ViewBag.Icon2 = weather.list[7].weather[0].icon;
            ViewBag.Icon3 = weather.list[15].weather[0].icon;
            ViewBag.Icon4 = weather.list[23].weather[0].icon;
            ViewBag.Icon5 = weather.list[31].weather[0].icon;

            return View();
        }
    }
}