#pragma warning disable CS8618
namespace SPG_Fachtheorie.Aufgabe1.Model;

public class Depot
{
    protected Depot() { }

    public Depot(string code, string name, Address address)
    {
        Code = code;
        Name = name;
        Address = address;
    }

    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
}
