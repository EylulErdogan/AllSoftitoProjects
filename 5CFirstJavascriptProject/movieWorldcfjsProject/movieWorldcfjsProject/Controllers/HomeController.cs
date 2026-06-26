using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieWorldcfjsProject.Data;

public class HomeController : Controller
{
    private readonly ApplicationDbContext context;

    public HomeController(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public JsonResult MovieList()
    {
        var data = context.Movies
            .Include(x => x.Category)
            .Include(x => x.Director)
            .ToList();

        return Json(data);
    }
    public JsonResult SearchMovie(string searchText)
    {
        var data = context.Movies
            .Include(x => x.Category)
            .Include(x => x.Director)
            .Where(x =>
                x.Title.Contains(searchText) ||
                x.Category.Name.Contains(searchText) ||
                x.Director.FullName.Contains(searchText))
            .ToList();

        return Json(data);
    }
    public IActionResult Details(int id)
    {
        ViewBag.Id = id;
        return View();
    }

    public JsonResult GetMovieById(int id)
    {
        var movie = context.Movies
            .Include(x => x.Category)
            .Include(x => x.Director)
            .FirstOrDefault(x => x.Id == id);

        return Json(movie);
    }
}