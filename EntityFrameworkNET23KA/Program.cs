using System;
using System.Linq;
using EntityFrameworkNET23KA.Models;

using var db = new MasterContext();

var customer = db.Customers
    .OrderBy(b => b.CustomerId)
    .First();

Console.WriteLine("Customer Details: " + customer.Name);


var customers = db.Customers.ToList();

foreach (var customerItem in customers)
{
    Console.WriteLine("Customer Details: " + customerItem.Name);
}
