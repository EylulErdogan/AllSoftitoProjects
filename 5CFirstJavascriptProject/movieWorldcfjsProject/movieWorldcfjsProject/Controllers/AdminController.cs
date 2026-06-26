using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieWorldcfjsProject.Data;
using movieWorldcfjsProject.Models;

public class AdminController : Controller
{
    private readonly ApplicationDbContext context;

    public AdminController(ApplicationDbContext context)
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

    public JsonResult GetCategories()
    {
        var values = context.Categories.ToList();
        return Json(values);
    }

    public JsonResult GetDirectors()
    {
        var values = context.Directors.ToList();
        return Json(values);
    }

    [HttpPost]
    public JsonResult AddMovie([FromBody] MovieCreateDto model)
    {
        int categoryId;

        if (!string.IsNullOrEmpty(model.NewCategoryName))
        {
            var category = new Category
            {
                Name = model.NewCategoryName
            };

            context.Categories.Add(category);
            context.SaveChanges();

            categoryId = category.Id;
        }
        else
        {
            categoryId = model.CategoryId.Value;
        }

        int directorId;

        if (!string.IsNullOrEmpty(model.NewDirectorName))
        {
            var director = new Director
            {
                FullName = model.NewDirectorName
            };

            context.Directors.Add(director);
            context.SaveChanges();

            directorId = director.Id;
        }
        else
        {
            directorId = model.DirectorId.Value;
        }

        var movie = new Movie
        {
            Title = model.Title,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            ReleaseYear = model.ReleaseYear,
            Imdb = model.Imdb,
            CategoryId = categoryId,
            DirectorId = directorId
        };

        context.Movies.Add(movie);
        context.SaveChanges();

        return Json(movie);
    }

    public IActionResult EditPanel()
    {
        return View();
    }
    [HttpPost]
    public JsonResult DeleteMovie(int id)
    {
        var movie = context.Movies.Find(id);

        if (movie == null)
        {
            return Json(false);
        }

        context.Movies.Remove(movie);
        context.SaveChanges();

        return Json(true);
    }

    [HttpPost]
    public JsonResult DeleteCategory(int id)
    {
        var category = context.Categories.Find(id);

        if (category == null)
        {
            return Json(false);
        }

        context.Categories.Remove(category);
        context.SaveChanges();

        return Json(true);
    }

    [HttpPost]
    public JsonResult DeleteDirector(int id)
    {
        var director = context.Directors.Find(id);

        if (director == null)
        {
            return Json(false);
        }

        context.Directors.Remove(director);
        context.SaveChanges();

        return Json(true);
    }
    [HttpPost]
    public JsonResult UpdateCategory(int id, string name)
    {
        var category = context.Categories.Find(id);

        if (category == null)
        {
            return Json(false);
        }

        category.Name = name;
        context.SaveChanges();

        return Json(true);
    }

    [HttpPost]
    public JsonResult UpdateDirector(int id, string fullName)
    {
        var director = context.Directors.Find(id);

        if (director == null)
        {
            return Json(false);
        }

        director.FullName = fullName;
        context.SaveChanges();

        return Json(true);
    }
}

