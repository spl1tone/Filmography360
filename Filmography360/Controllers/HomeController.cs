using Filmography360.DataBase.DbContextController;
using Microsoft.AspNetCore.Mvc;

namespace Filmography360.Controllers;

public class HomeController : Controller
{

    private readonly MainDbContext _db;

    public HomeController (MainDbContext db)
    {
        _db = db;
    }

    public IActionResult IndexDark ()
    {
        return View("indexDark");
    }

    public IActionResult AboutMeDark ()
    {
        return View("aboutMeDark");
    }

    public IActionResult Index (string sortOrder)
    {
        ViewBag.SortOrder = sortOrder;
        return View("indexDark");
    }

    public IActionResult FilmInfoDark (int id)
    {
        var film = _db.FilmInfos.FirstOrDefault(f => f.Id == id);

        ViewBag.Id = film.Id;

        return View("filmInfoDark");
    }

    [Route("Home/ActorInfoDark/{id}")]
    public IActionResult ActorInfoDark (int id)
    {
        var actor = _db.Actors.FirstOrDefault(a => a.Id == id);

        ViewBag.ActorId = actor.Id;

        return View("actorInfoDark");
    }

}
