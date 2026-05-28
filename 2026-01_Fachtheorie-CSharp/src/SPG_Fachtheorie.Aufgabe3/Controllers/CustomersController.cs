using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe2.Infrastructure;
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

    /// <summary>
    /// Diese REST API Route soll eine Liste von Kunden zurückliefern.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<List<CustomerDto>> GetAllCustomers()
    {
        // TODO: Add your implementation
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gültige Preorders in der Datenbank (zum Testen) sind
    /// 52189, 48813, 75195, 57911
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [HttpGet("preorder/{code}")]
    public ActionResult<PreorderDto> GetPreorders(string code)
    {
        // TODO: Add your implementation
        throw new NotImplementedException();
    }

    /// <summary>
    /// Diese REST API Route soll einen neuen Kunden erstellen.
    /// </summary>
    [HttpPost]
    public IActionResult AddCustomer(NewCustomerCmd cmd)
    {
        // TODO: Add your implementation
        throw new NotImplementedException();
    }

    /// <summary>
    /// Dieser Endpunkt soll Kunden aus der Datenbank löschen. Die übergebene ID als Routingpara­-
    /// meter ist der Wert in Customer.Id. Sie dürfen den Kunden allerdings nur löschen, wenn keine
    /// Preorders für diesen Kunden in der Datenbank vorhanden sind.
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        // TODO: Add your implementation
        throw new NotImplementedException();
    }
}
