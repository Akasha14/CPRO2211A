using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context {  get; set; }

        public HomeController(MovieContext ctx)
        {
            context = ctx;
        }
        // Index method, default page.
        [Route("/")]
        public IActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre)
                .OrderBy(m => m.Name).ToList();
            return View(movies);
        }
    }
}
