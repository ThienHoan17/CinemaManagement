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
        [HttpGet]
        public IActionResult Create()
        {
            var movie = new Movie();
            using (var dbContext = new MovieDbContext())
            {
                var categories = dbContext.Categories.ToList();
                ViewBag.Categories = categories;
            }
            return View(movie);
        }
        [HttpPost]
        public IActionResult Create(Movie model)
        {
            model.ImageUrl = "/star-wars-jedi-fallen-order-danh-gia.jpg";
            using (var dbContext = new MovieDbContext())
            {
                var categories = dbContext.Movies.Add(model);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int movieId)
        {
            Movie movie;
            using (var dbContext = new MovieDbContext())
            {
                movie = dbContext.Movies.Single(x=> x.Id == movieId);

                var categories = dbContext.Categories.ToList();
                ViewBag.Categories = categories;
            }
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie model)
        {          
            using (var dbContext = new MovieDbContext())
            {
                var movieDb = dbContext.Movies.Single(x => x.Id == model.Id);
                movieDb.Name = model.Name;
                movieDb.CategoryId = model.CategoryId;
                movieDb.Director = model.Director;
                movieDb.Ownner = model.Ownner;
                movieDb.Year = model.Year;
                var categories = dbContext.Movies.Update(movieDb);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
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
