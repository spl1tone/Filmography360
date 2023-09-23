using Microsoft.AspNetCore.Mvc;

namespace Filmography360.Controllers;

public class HomeController : Controller
{
    public IActionResult MainPage ()
    {
        return View();
    }
}
