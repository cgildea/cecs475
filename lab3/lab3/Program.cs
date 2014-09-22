using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}{6,-10}\n", "Broker", "Stock", "Initial", "Current", "Difference", "Changes", "Date");

            Stock stock1 = new Stock("Technology", 160, 5, 15);
            Stock stock2 = new Stock("Retail", 30, 2, 6);
            Stock stock3 = new Stock("Banking", 90, 4, 10);
            Stock stock4 = new Stock("Commodity", 500, 20, 50);

            StockBroker b1 = new StockBroker("Broker 1");
            b1.addStock(stock1);
            b1.addStock(stock2);

            StockBroker b2 = new StockBroker("Broker 2");
            b2.addStock(stock1);
            b2.addStock(stock3);
            b2.addStock(stock4);

            StockBroker b3 = new StockBroker("Broker 3");
            b3.addStock(stock1);
            b3.addStock(stock3);

            StockBroker b4 = new StockBroker("Broker 4");
            b4.addStock(stock1);
            b4.addStock(stock2);
            b4.addStock(stock3);
            b4.addStock(stock4);
        }
    }
}
