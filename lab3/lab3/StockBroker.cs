using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3
{
    class StockBroker
    {
        public static event EventHandler _stockPrint;

        public String BrokerName { get; private set; }
        public List<Stock> stocks { get; private set; }

        public StockBroker(String name)
        {
            this.BrokerName = name;
            
        }

	    public void addStock(Stock s){
            s.ThresholdReached += s_ThresholdReached; //To Text File
	    }

        void s_ThresholdReached(Object sender, ThresholdReachedEventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\User\\dev\\cecs475\\lab3\\lab3\\lab3Output.txt", true);

            if (e.difference > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}\n", BrokerName, e.name, e.initialValue, e.currentValue, e.difference, e.changes);

                file.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}\n", BrokerName, e.name, e.initialValue, e.currentValue, e.difference, e.changes);

                file.Close();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}\n", BrokerName, e.name, e.initialValue, e.currentValue, e.difference, e.changes);

                file.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}\n", BrokerName, e.name, e.initialValue, e.currentValue, e.difference, e.changes);

                file.Close();
            }
            
        }
    }
}
