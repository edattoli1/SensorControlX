using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCcontrol
{
    class Util
    {
        public class ADstorage
        {
            // single instance of class which is created on declaration
            static readonly ADstorage _instance = new ADstorage();

            // returns the above single instance
            public static ADstorage Instance
            {
                get
                {
                    return _instance;
                }
            }

            public Stack<double> inTimesQ { get; set; }
            public Stack<double> readMFC1 { get; set; }
            public Stack<double> readMFC2 { get; set; }

            public ADstorage()
            {
                inTimesQ = new Stack<double>(new List<double> { });
                readMFC1 = new Stack<double>(new List<double> { });
                readMFC2 = new Stack<double>(new List<double> { });
            }
        }
        
        
        public async Task LongDelay()
        {
            //simulate a long delay

            int b = await Task.Run(() =>
             {
                 //Task.Delay(10000);
                 for (int i = 0; i < 1000000000000000; i++)
                 {
                     i = i * 2;
                 }
                 return 1;

             });
        }
    }
}
