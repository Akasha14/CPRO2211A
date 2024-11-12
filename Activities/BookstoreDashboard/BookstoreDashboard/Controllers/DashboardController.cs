using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace BookstoreDashboard.Controllers
{
    [Authorize] // Require authentication for accessing the dashboard
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Load the dashboard view
        }
    }
}

