using Microsoft.AspNetCore.Mvc;

namespace Filmography360.Controllers;

public class HomeController : Controller
{
    public IActionResult IndexDark ()
    {
        return View("indexDark");
    }

    public IActionResult AboutMeDark ()
    {
        return View("aboutMeDark");
    }

    public IActionResult FilmInfoDark (string filmName)
    {
        var film = Filmography360.FakerInfo.FakerInfo.FilmList.FirstOrDefault(f => f.Name == filmName);
        if (film == null) {
            return NotFound();
        }

        return View(film);
    }

}
