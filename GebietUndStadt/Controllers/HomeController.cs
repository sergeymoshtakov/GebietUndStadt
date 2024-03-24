using GebietUndStadt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GebietUndStadt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<City> _cities;
        private List<Oblast> _oblasts;
        private List<Street> _streets;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _oblasts = new List<Oblast>
            {
                new Oblast { Id = 1, Name = "Odessa Oblast" },
                new Oblast { Id = 2, Name = "Kherson Oblast" },
                new Oblast { Id = 3, Name = "Lviv Oblast" },
                new Oblast { Id = 4, Name = "Mykolaiv Oblast"}
            };
            _cities = new List<City>
            {
                new City { Id = 1, Name = "Odessa", OblastId = 1 },
                new City { Id = 2, Name = "Kherson", OblastId = 2 },
                new City { Id = 3, Name = "Lviv", OblastId = 3 },
                new City { Id = 4, Name = "Mykolaiv", OblastId = 4 },
                new City { Id = 5, Name = "Oleshki", OblastId = 2},
                new City { Id = 6, Name = "Kakhovka", OblastId = 2 },
                new City { Id = 7, Name = "Balta", OblastId = 1 },
                new City { Id = 8, Name = "Bilgorod-Dnistrovskii", OblastId = 1 },
                new City { Id = 9, Name = "Mostiska", OblastId = 3 },
                new City { Id = 10, Name = "Stryi", OblastId = 3 },
                new City { Id = 11, Name = "Skadovsk", OblastId = 2 },
                new City { Id = 12, Name = "Vylkove", OblastId = 1 },
                new City { Id = 13, Name = "Nova Kakhovka", OblastId = 2 },
                new City { Id = 14, Name = "Kiliya", OblastId = 1 },
                new City { Id = 15, Name = "Genichensk", OblastId = 2 },
                new City { Id = 16, Name = "Ochakov", OblastId = 4 },
                new City { Id = 17, Name = "Pervomaisk", OblastId = 4 },
                new City { Id = 18, Name = "Voznesensk", OblastId = 4 },
                new City { Id = 19, Name = "Yuzhnoukrainsk", OblastId = 4 },
                new City { Id = 20, Name = "Drogobych", OblastId = 3 },
                new City { Id = 21, Name = "Snegirevka", OblastId = 4 },
                new City { Id = 22, Name = "Izmail", OblastId = 1 },
                new City { Id = 23, Name = "Berezovka", OblastId = 1 },
                new City { Id = 24, Name = "Reni", OblastId = 1 },
                new City { Id = 25, Name = "Bolgrad", OblastId = 1 },
            };
            _streets = new List<Street>
            {
                new Street { Id = 1, Name = "Deribasovskaya", CityId = 1 },
                new Street { Id = 3, Name = "Rishelyevskaya", CityId = 1 },
                new Street { Id = 4, Name = "Malaya Arnautskaya", CityId = 1 },
                new Street { Id = 5, Name = "Targova", CityId = 2 },
                new Street { Id = 6, Name = "Sobornaya", CityId = 2 },
                new Street { Id = 7, Name = "Korabelnaya", CityId = 2 },
                new Street { Id = 8, Name = "Svobody", CityId = 3 },
                new Street { Id = 9, Name = "Kopernika", CityId = 3 },
                new Street { Id = 10, Name = "Knyazya Romana", CityId = 3 },
                new Street { Id = 11, Name = "Soborna", CityId = 4 },
                new Street { Id = 12, Name = "Bolshaya", CityId = 4 },
                new Street { Id = 13, Name = "Mira", CityId = 4 },
                new Street { Id = 14, Name = "Korabelnaya", CityId = 5 },
                new Street { Id = 15, Name = "Svobody", CityId = 5 },
                new Street { Id = 16, Name = "Kopernika", CityId = 5 },
                new Street { Id = 17, Name = "Knyazya Romana", CityId = 6 },
                new Street { Id = 18, Name = "Soborna", CityId = 6 },
                new Street { Id = 19, Name = "Bolshaya", CityId = 6 },
                new Street { Id = 20, Name = "Mira", CityId = 7 },
                new Street { Id = 21, Name = "Korabelnaya", CityId = 7 },
                new Street { Id = 22, Name = "Svobody", CityId = 7 },
                new Street { Id = 23, Name = "Kopernika", CityId = 8 },
                new Street { Id = 24, Name = "Knyazya Romana", CityId = 8 },
                new Street { Id = 25, Name = "Soborna", CityId = 8 },
                new Street { Id = 26, Name = "Bolshaya", CityId = 9 },
                new Street { Id = 27, Name = "Mira", CityId = 9 },
                new Street { Id = 28, Name = "Korabelnaya", CityId = 9 },
                new Street { Id = 29, Name = "Svobody", CityId = 10 },
                new Street { Id = 30, Name = "Kopernika", CityId = 10 },
                new Street { Id = 31, Name = "Knyazya Romana", CityId = 10 },
                new Street { Id = 32, Name = "Soborna", CityId = 11 },
                new Street { Id = 33, Name = "Bolshaya", CityId = 11 },
                new Street { Id = 34, Name = "Mira", CityId = 11 },
                new Street { Id = 35, Name = "Korabelnaya", CityId = 12 },
                new Street { Id = 36, Name = "Svobody", CityId = 12 },
                new Street { Id = 37, Name = "Kopernika", CityId = 12 },
                new Street { Id = 38, Name = "Knyazya Romana", CityId = 13 },
                new Street { Id = 39, Name = "Soborna", CityId = 13 },
                new Street { Id = 40, Name = "Bolshaya", CityId = 13 },
                new Street { Id = 41, Name = "Mira", CityId = 14 },
                new Street { Id = 42, Name = "Korabelnaya", CityId = 14 },
                new Street { Id = 43, Name = "Svobody", CityId = 14 },
                new Street { Id = 44, Name = "Kopernika", CityId = 15 },
                new Street { Id = 45, Name = "Knyazya Romana", CityId = 15 },
                new Street { Id = 46, Name = "Soborna", CityId = 15 },
                new Street { Id = 47, Name = "Bolshaya", CityId = 16 },
                new Street { Id = 48, Name = "Mira", CityId = 16 },
                new Street { Id = 49, Name = "Korabelnaya", CityId = 16 },
                new Street { Id = 50, Name = "Svobody", CityId = 17 },
                new Street { Id = 51, Name = "Kopernika", CityId = 17 },
                new Street { Id = 52, Name = "Knyazya Romana", CityId = 17 },
                new Street { Id = 53, Name = "Soborna", CityId = 18 },
                new Street { Id = 54, Name = "Bolshaya", CityId = 18 },
                new Street { Id = 55, Name = "Mira", CityId = 18 },
                new Street { Id = 56, Name = "Korabelnaya", CityId = 19 },
                new Street { Id = 57, Name = "Svobody", CityId = 19 },
                new Street { Id = 58, Name = "Kopernika", CityId = 19 },
                new Street { Id = 59, Name = "Knyazya Romana", CityId = 20 },
                new Street { Id = 60, Name = "Soborna", CityId = 20 },
                new Street { Id = 61, Name = "Bolshaya", CityId = 20 },
                new Street { Id = 62, Name = "Mira", CityId = 21 },
                new Street { Id = 63, Name = "Korabelnaya", CityId = 21 },
                new Street { Id = 64, Name = "Svobody", CityId = 21 },
                new Street { Id = 65, Name = "Kopernika", CityId = 22 },
                new Street { Id = 66, Name = "Knyazya Romana", CityId = 22 },
                new Street { Id = 67, Name = "Soborna", CityId = 22 },
                new Street { Id = 68, Name = "Bolshaya", CityId = 23 },
                new Street { Id = 69, Name = "Mira", CityId = 23 },
                new Street { Id = 70, Name = "Korabelnaya", CityId = 23 },
                new Street { Id = 71, Name = "Svobody", CityId = 24 },
                new Street { Id = 72, Name = "Kopernika", CityId = 24 },
                new Street { Id = 73, Name = "Knyazya Romana", CityId = 24 },
                new Street { Id = 74, Name = "Soborna", CityId = 25 },
                new Street { Id = 75, Name = "Bolshaya", CityId = 25 },
                new Street { Id = 76, Name = "Mira", CityId = 25 }
            };
        }

        public IActionResult Index()
        {
            ViewBag.Oblasts = _oblasts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult GetCities(int oblastId)
        {
            List<City> cities = _cities.FindAll(c => c.OblastId == oblastId);
            return Json(cities);
        }

        [HttpPost]
        public IActionResult GetStreets(int cityId)
        {
            List<Street> streets = _streets.FindAll(c => c.CityId == cityId);
            return Json(streets);
        }
    }
}
