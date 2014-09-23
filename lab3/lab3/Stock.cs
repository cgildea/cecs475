using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3
{
    class Stock
    {
        public String name{get; private set;}
        public int initialValue{get; private set;}
        public int currentValue{get; private set;}
        public int maxChange{get; private set;}
        public int threshold{get; private set;}
        public int changes { get; private set; }
        public int difference { get; private set; }
        public int stockChange { get; private set; }


        private Thread thread;

        public Stock(String name, int initialValue, int maxChange, int threshold)
        {
            this.name = name;
            this.initialValue = initialValue;
            this.maxChange = maxChange;
            this.threshold = threshold;
            this.changes = 0;
            thread = new Thread(new ThreadStart(Activate));
            thread.Start();
        }
        public void Activate(){
		    for(;;){
                Thread.Sleep(500);
			    changeStockValue();
		    }
	    }

	    public void changeStockValue(){
            Random rnd = new Random();
		    currentValue = initialValue + rnd.Next(-maxChange, maxChange);
            if (currentValue < 0)
                currentValue = 0;

            stockChange += Math.Abs(currentValue - initialValue);
            changes++;
            ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();

            if (stockChange >= threshold)
            {
                this.difference = this.currentValue - this.initialValue;
                args.name = this.name;
                args.initialValue = this.initialValue;
                args.currentValue = this.currentValue;
                args.changes = this.changes;
                args.difference = this.difference;
                this.initialValue = this.currentValue;
                OnThresholdReached(args);
            }
            else
            {
                this.initialValue = this.currentValue;
            }
	    }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            ThresholdReachedEventHandler handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event ThresholdReachedEventHandler ThresholdReached;

    }
    public class ThresholdReachedEventArgs : EventArgs
    {
        public String name { get; set; }
        public int initialValue { get; set; }
        public int currentValue { get; set; }
        public int changes { get; set; }
        public int difference { get; set; }
    }
    public delegate void ThresholdReachedEventHandler(Object sender, ThresholdReachedEventArgs e);
}
