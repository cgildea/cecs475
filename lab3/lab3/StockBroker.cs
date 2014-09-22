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
        FilePrint fp = new FilePrint();

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
            

            fp.PrintToFile(BrokerName, e.name, e.initialValue, e.currentValue, e.difference, e.changes, DateTime.Now);
        }
    }
}
