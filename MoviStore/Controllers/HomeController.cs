using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Director = "Peter Cameron",
                    Name = "Star War",
                    Year = 2020,
                    Ownner = "Wanderos"
                },
                 new Movie
                {
                    Id = 2,
                    Director = "Hoan",
                    Name = "Return of Kings",
                    Year = 2019,
                    Ownner = "Columbia Picture"
                },
                  new Movie
                {
                    Id = 3,
                    Director = "Tien",
                    Name = "Fairy",
                    Year = 2020,
                    Ownner = "Sony Picture"
                },
                   new Movie
                {
                    Id = 4,
                    Director = "Cameron",
                    Name = "Superman",
                    Year = 2020,
                    Ownner = "DC"
                },
                    new Movie
                {
                    Id = 5,
                    Director = "ABC",
                    Name = "Avenger",
                    Year = 2020,
                    Ownner = "Marvel Studio"
                },
                new Movie
                {
                    Id = 6,
                    Director = "Peter",
                    Name = "Doremon",
                    Year = 2020,
                    Ownner = "Wanderos"
                }
            };
            return View(movies);
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
    }
}
