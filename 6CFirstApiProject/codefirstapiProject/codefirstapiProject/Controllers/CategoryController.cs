using codefirstapiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codefirstapiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        private readonly AppDbContext context;
        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetCategory")]
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await context.Categories.ToListAsync();
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<Category> AddCategory(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();

            return category;
        }

        [HttpPut]
        [Route("UpdateCategory/{id}")]
        public async Task<Category> UpdateCategory(Category category, int id)
        {
            category.Id = id;

            context.Entry(category).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return category;
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public bool DeleteCategory(int id)
        {
            bool a = false;

            var category = context.Categories.Find(id);

            if (category != null)
            {
                a = true;
                context.Entry(category).State = EntityState.Deleted;
                context.SaveChanges();
            }

            return a;
        }
    }
}
