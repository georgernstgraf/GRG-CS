#pragma warning disable CS8618
namespace SPG_Fachtheorie.Aufgabe1.Model;
public class Customer
{
    protected Customer() { }

    public Customer(string firstname, string lastname, string email, string phone, Address address)
    {
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        Phone = phone;
        Address = address;
    }

    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
}
