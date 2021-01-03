using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviStore.Models;
using MoviStore.ViewModel;
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
            using (var dbContext = new MovieDbContext())
            {
                var movies = dbContext.Movies.Select(x => new MovieVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Director = x.Director,
                    ImageUrl = x.ImageUrl,
                    Ownner = x.Ownner,
                    ShowDate = x.ShowDate,
                    Year = x.Year

                }).ToList();
                return View(movies);
            }
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
