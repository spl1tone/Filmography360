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

    public IActionResult FilmInfoDark (int id)
    {
        var film = Filmography360.FakerInfo.FakerInfo.FilmList.FirstOrDefault(f => f.Id == id);

        ViewBag.Id = film.Id;

        return View("filmInfoDark");
    }

    [Route("Home/ActorInfoDark/{id}")]
    public IActionResult ActorInfoDark (int id)
    {
        var actor = Filmography360.FakerInfo.FakerInfo.ActorList.FirstOrDefault(a => a.Id == id);

        ViewBag.ActorId = actor.Id;

        return View("actorInfoDark");
    }

}
