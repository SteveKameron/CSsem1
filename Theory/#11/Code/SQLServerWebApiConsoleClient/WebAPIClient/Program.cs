using System.Net.Http.Json;
using WebAPIModels.Models;

string uri = $"https://localhost:7026/api/Customers";
HttpClient client = new HttpClient();

var chapter = await client.GetFromJsonAsync<IEnumerable<Customer>>(uri);
if (chapter is not null)
{
    foreach(var c in chapter)
    {
        Console.WriteLine($"{c.City}: {c.ContactName} : {c.Country} ");
    }
}

Customer customer = new Customer()
{
    Address = "Russia",
    City = "Moscow",
    CompanyName = "BMSTU",
    ContactName = "Alexander",
    ContactTitle = "K",
    Country = "RU",
    CustomerId = "01",
    Fax = "88007556535",
    Phone = "88007556535",
    PostalCode = "451042",
    Region = "Rus"
};
//var result = await client.PostAsJsonAsync<Customer>(uri, customer);

Console.ReadLine();



