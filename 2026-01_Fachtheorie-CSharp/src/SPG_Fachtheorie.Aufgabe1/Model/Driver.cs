#pragma warning disable CS8618
namespace SPG_Fachtheorie.Aufgabe1.Model;

public class Driver
{
    protected Driver() { }

    public Driver(int employeeNo, string firstName, string lastName, Depot currentDepot)
    {
        EmployeeNo = employeeNo;
        FirstName = firstName;
        LastName = lastName;
        CurrentDepot = currentDepot;
    }

    public int EmployeeNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Depot CurrentDepot { get; set; }
}
