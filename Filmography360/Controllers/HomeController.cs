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
        // Отримайте дані про фільм зі списку FilmList за ідентифікатором.
        var film = Filmography360.FakerInfo.FakerInfo.FilmList.FirstOrDefault(f => f.Id == id);

        ViewBag.Id = film.Id;

        // Передайте дані про фільм в перегляд для відображення.
        return View("filmInfoDark");
    }

    public IActionResult ActorInfoDark (int id)
    {
        // Отримайте дані про фільм зі списку FilmList за ідентифікатором.
        var actor = Filmography360.FakerInfo.FakerInfo.ActorList.FirstOrDefault(a => a.Id == id);

        ViewBag.ActorId = actor.Id;

        // Передайте дані про фільм в перегляд для відображення.
        return View("actorInfoDark");
    }

}
