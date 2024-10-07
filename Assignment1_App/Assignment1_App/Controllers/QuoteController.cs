using Microsoft.AspNetCore.Mvc;
using Assignment1_App.Models;

public class QuoteController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        // Default page.
        return View(new QuoteModel());
    }

    [HttpPost]
    public IActionResult Index(QuoteModel model)
    {
        // Results.
        return View(model);
    }

    [HttpGet]
    public IActionResult Clear()
    {
        return RedirectToAction("Index");
    }
}