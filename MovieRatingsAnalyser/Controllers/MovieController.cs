using Microsoft.AspNetCore.Mvc;
using MovieRatingsAnalyser.Models;
using MovieRatingsAnalyser.Services;

namespace MovieRatingsAnalyser.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieServiceImpl _movieService;

        public MovieController(MovieServiceImpl movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            ViewBag.TopedRatedMovies = _movieService.GetTopRatedMovies(5);
            ViewBag.WorstRatedMovies = _movieService.GetWorstRatedMovies(5);
            ViewBag.AverageRating = _movieService.GetAverageRating();
            ViewBag.BestYear = _movieService.GetTheBestYear();
            return View(movies);
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
                _movieService.AddMovie(movie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _movieService.GetAllMovies().FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie movie)
        {
            if (ModelState.IsValid)
                _movieService.UpdateMovie(movie);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }

    }
}
