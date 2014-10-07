using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
           Invoice[] invoices = 
           {    
                new Invoice(83, "Electric sander", 7, 57.98m),
                new Invoice(24, "Power saw", 18, 99.99m),
                new Invoice(7, "Sledge hammer", 11, 21.50m),
                new Invoice(77, "Hammer", 76, 11.99m),
                new Invoice(39, "Lawn mower", 3, 79.50m),
                new Invoice(68, "Screwdriver", 106, 6.99m),
                new Invoice(56, "Jig saw", 21, 11.00m),
                new Invoice(3, "Wrench", 34, 7.50m)
           };

           var descriptions = from i in invoices
                             orderby i.PartDescription
                             select new { i.PartNumber, i.PartDescription, i.Quantity, i.Price };

           Console.WriteLine("Ordered by Description:");
           foreach (var invoice in descriptions)
           {
               Console.WriteLine("{0, -10}{1, -20}{2, -10}{3, -10}", invoice.PartNumber,
                   invoice.PartDescription, invoice.Quantity, invoice.Price);
           }
           Console.WriteLine("\n\nOrdered by Price:");
           var prices = from i in invoices
                             orderby i.Price
                             select new { i.PartNumber, i.PartDescription, i.Quantity, i.Price };

           foreach (var invoice in prices)
           {
               Console.WriteLine("{0, -10}{1, -20}{2, -10}{3, -10}", invoice.PartNumber,
                   invoice.PartDescription, invoice.Quantity, invoice.Price);
           }

           Console.WriteLine("\n\nDescription and Quantity; Ordered by Quantity:");
           var descQuantity = from i in invoices
                        orderby i.Quantity
                        select new {i.PartDescription, i.Quantity};

           foreach (var invoice in descQuantity)
           {
               Console.WriteLine("{0, -20}{1, -10}",
                   invoice.PartDescription, invoice.Quantity);
           }

           Console.WriteLine("\n\nInvoice Total; Ordered by Value:");
           var invoiceTotal = from i in invoices
                              let total = i.Price * i.Quantity
                              orderby total
                              select new { i.PartDescription, i.Quantity, total };

           foreach (var invoice in invoiceTotal)
           {
               Console.WriteLine("{0, -20}{1, -10}{2, -10}",
                   invoice.PartDescription, invoice.Quantity, invoice.total);
           }

           var invoiceTotalRange = from t in invoiceTotal
                                   where t.total >= 200 && t.total <= 500
                                   select new { t.PartDescription, t.Quantity, t.total };

           Console.WriteLine("\n\nInvoice Total Range; Ordered by Value:");

           foreach (var invoice in invoiceTotalRange)
           {
               Console.WriteLine("{0, -20}{1, -10}{2, -10}",
                   invoice.PartDescription, invoice.Quantity, invoice.total);
           }
        }
    }
}
