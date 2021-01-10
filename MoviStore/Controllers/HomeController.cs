using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviStore.Models;
using Service;
using System.Diagnostics;

namespace MoviStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Index(string query = "")
        {
            var movies = _movieService.Search(query);
            ViewBag.Query = query;
            return View(movies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var movie = new Movie();
            var categories = _movieService.GetCategories();
            ViewBag.Categories = categories;
            return View(movie);
        }
        [HttpPost]
        public IActionResult Create(Movie model)
        {

            _movieService.Create(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int movieId)
        {
            Movie movie;

            movie = _movieService.GetMovieById(movieId);
            var categories = _movieService.GetCategories();
            ViewBag.Categories = categories;
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            _movieService.Update(model);
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
