using Microsoft.AspNetCore.Mvc;
using Assignment1_App.Models;

public class QuoteController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new QuoteModel());
    }

    [HttpPost]
    public IActionResult Index(QuoteModel model)
    {
        return View(model);
    }

    [HttpGet]
    public IActionResult Clear()
    {
        // Reset the form by redirecting to the Index action
        return RedirectToAction("Index");
    }
}