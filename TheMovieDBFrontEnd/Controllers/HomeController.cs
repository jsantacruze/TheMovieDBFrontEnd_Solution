using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheMovieDBFrontEnd.DataSources;
using TheMovieDBFrontEnd.Models;
using TheMovieDBFrontEnd.Models.Movies;

namespace TheMovieDBFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Movie> movies = await new MoviedbDatasource().getNowPlaying();
            return View(movies);
        }

        public async Task<IActionResult> Upcoming()
        {
            List<Movie> movies = await new MoviedbDatasource().getUpcoming();
            return View(movies);
        }

        public async Task<IActionResult> Detail(long id)
        {
            Movie movie = await new MoviedbDatasource().getMovieDeail(id);
            return View(movie);
        }

    }
}