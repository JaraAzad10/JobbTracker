using Microsoft.AspNetCore.Mvc;

namespace JobbTracker.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var firmaer = new List<string> {"DNB", "Equinor", "Visma"};
        return View(firmaer); //sender listen til viewet
    }

    public IActionResult Om()
    {
        return View();
    }
}