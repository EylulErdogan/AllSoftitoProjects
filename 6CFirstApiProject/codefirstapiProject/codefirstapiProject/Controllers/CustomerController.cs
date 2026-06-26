using codefirstapiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codefirstapiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public CustomersController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await dbContext.Customers.ToListAsync();
        }

        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpPut]
        [Route("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(customer).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            dbContext.Customers.Remove(customer);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}