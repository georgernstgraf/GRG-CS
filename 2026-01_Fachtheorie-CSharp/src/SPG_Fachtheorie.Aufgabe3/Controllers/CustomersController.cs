using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe2.Infrastructure;
using SPG_Fachtheorie.Aufgabe2.Model;
using SPG_Fachtheorie.Aufgabe3.Cmds;
using SPG_Fachtheorie.Aufgabe3.Dtos;

namespace SPG_Fachtheorie.Aufgabe3.Controllers;
[Route("[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly OnlineStoreContext _db;

    public CustomersController(OnlineStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
    {
        var customers = await _db.Customers
            .Select(c => new CustomerDto(c.Id, c.FirstName, c.LastName, c.Email, c.Phone))
            .ToListAsync();
        return Ok(customers);
    }

    [HttpGet("preorder/{code}")]
    public async Task<ActionResult<PreorderDto>> GetPreorders(string code)
    {
        if (code.Length < 5)
            return Problem("Code must be at least 5 characters long.", statusCode: 400);

        var preorder = await _db.Preorders
            .Include(p => p.PreorderItems)
            .ThenInclude(pi => pi.Product)
            .FirstOrDefaultAsync(p => p.Code == code);

        if (preorder is null)
            return Problem("Preorder not found.", statusCode: 404);

        var dto = new PreorderDto(
            preorder.PlacedAt,
            preorder.TotalAmount,
            preorder.PreorderItems
                .Select(pi => new PreorderItemDto(pi.Product.Name, pi.Quantity, pi.UnitPrice))
                .ToList());

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(NewCustomerCmd cmd)
    {
        if (string.IsNullOrEmpty(cmd.FirstName) || cmd.FirstName.Length > 255)
            return Problem("FirstName must be between 1 and 255 characters.", statusCode: 400);

        if (string.IsNullOrEmpty(cmd.LastName) || cmd.LastName.Length > 255)
            return Problem("LastName must be between 1 and 255 characters.", statusCode: 400);

        if (!cmd.Email.Contains('@'))
            return Problem("Email must contain an @ sign.", statusCode: 400);

        var customer = new Customer(cmd.FirstName, cmd.LastName, cmd.Email, cmd.Phone);
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();

        return Created("", new { id = customer.Id });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (customer is null)
            return Problem("Customer not found.", statusCode: 404);

        var hasPreorders = await _db.Preorders.AnyAsync(p => p.Customer.Id == id);
        if (hasPreorders)
            return Problem("Customer has preorders and cannot be deleted.", statusCode: 400);

        _db.Customers.Remove(customer);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
