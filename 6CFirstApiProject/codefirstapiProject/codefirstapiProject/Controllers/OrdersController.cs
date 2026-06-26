using codefirstapiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codefirstapiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public OrdersController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await dbContext.Orders.ToListAsync();
        }

        [HttpGet]
        [Route("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await dbContext.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return Ok(order);
        }

        [HttpPut]
        [Route("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(order).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return Ok(order);
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await dbContext.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}