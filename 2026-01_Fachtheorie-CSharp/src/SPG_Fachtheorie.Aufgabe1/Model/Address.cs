#pragma warning disable CS8618
namespace SPG_Fachtheorie.Aufgabe1.Model;

public class Address
{
    protected Address() { }

    public Address(string street, string zip, string city, string country)
    {
        Street = street;
        Zip = zip;
        City = city;
        Country = country;
    }

    public string Street { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}


