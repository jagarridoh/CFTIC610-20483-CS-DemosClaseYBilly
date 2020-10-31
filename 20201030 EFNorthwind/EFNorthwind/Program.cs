using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace EFNorthwind
{
    class Program
    {
        static void Main() //string[] args
        {
            // Definimos una variable de tipo context de la base de datos.
            var db = new NorthwindEntities();
            // Mostrar por pantalla todos los "Clientes":
            foreach(var customer1 in db.Customers)
            {
                WriteLine($"{customer1.CompanyName} \t{customer1.ContactName} \t{customer1.Country}");
            }
            PressKey();
            WriteLine("El primer cliente de la lista");
            Customer customer = db.Customers.FirstOrDefault(e => e.ContactName == "Antonio Moreno");
            //Customer customer = db.Customers.First(e => e.ContactName == "Ant--onio Moreno");
            if (customer != null)
            {
                WriteLine(customer.CompanyName);
                WriteLine(customer.CustomerID);
                WriteLine(customer.Country);
                WriteLine(customer.City);
                WriteLine(customer.Phone);
            }
            PressKey();
            WriteLine("Actauliziadno un registro en la BD.");
            Customer customer2 = db.Customers.FirstOrDefault(e => e.ContactName == "Liz Nixon");
            if (customer2 != null)
            {
                WriteLine($"Cambiando el telefono de {customer2.ContactName} de {customer2.Phone}");
                customer2.Phone = "12344567";
                db.SaveChanges();
            }
            PressKey();
            //Una agrupacion por pais y el resultado nomrre de la compàñia y la persona de cotacto:
            WriteLine("Listando con agrupacion");
            var cus2 = from e in db.Customers
                       group e by e.Country into eGroup
                       select new { Country = eGroup.Key, CustomersByCountry = eGroup};
            foreach (var c in cus2)
            {
                Write($"Pais: {c.Country}: ");
                WriteLine(c.CustomersByCountry.Count());
            }
            PressKey();
            WriteLine("Agrupacion con la lambda de expresion");
            var userGroupByCountry = db.Customers.GroupBy(Customer => Customer.Country);
            foreach(var c in userGroupByCountry)
            {
                Write($"{c.Key}");
                WriteLine(c.Count());
                foreach(var cun in c)
                {
                    WriteLine($"\t\t{cun.CompanyName}");
                }
            }
            PressKey();
            WriteLine("Llamadas con relacion entre entidades - Dot Notation");
            var ordenes = from o in db.Order_Details
                          where o.OrderID == 10611
                          select new
                          {
                              ProductID = o.ProductID,
                              OrderID = o.OrderID,
                              Order = o.Order.ShipCountry
                          };
            foreach(var or in ordenes)
            {
                WriteLine($"Orden: País: {or.Order}, ID: {or.ProductID}, Numero de orden: {or.OrderID}");
            }
            PressKey();
        }

        public static void PressKey()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
        }
    }
}
