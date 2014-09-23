using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class FilePrint
    {
        String path; 

        public FilePrint()
        {
            path = @" C:\\Users\\User\\dev\\cecs475\\lab3\\lab3\\lab3Output.txt";
        }

        public void PrintToFile(String brokerName, String stockName, int initialValue, int currentValue, int difference, int changes, DateTime timeStamp)
        {
            using (StreamWriter print = File.AppendText(path))
            {
                try
                {
                    if (difference > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}{6,-10}\n", brokerName, stockName, initialValue, currentValue,
                                difference, changes, timeStamp.ToString());

                        print.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}{6,-10}\n", brokerName, stockName, initialValue, currentValue,
                                difference, changes, timeStamp.ToString());
                        print.Close();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}{6,-10}\n", brokerName, stockName, initialValue, currentValue,
                                difference, changes, timeStamp.ToString());

                        print.WriteLine("{0,-15}{1,-10}\t{2,-10}{3,-10}{4,-15}{5,-10}{6,-10}\n", brokerName, stockName, initialValue, currentValue,
                                difference, changes, timeStamp.ToString());
                        print.Close();
                    }
                }
                catch (IOException)
                {

                }
                
                
            }
            
            
        }
        
    }
}
