using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace GenericPenaltyCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDailyPenaltyFree();
        }

        private List<DateTime> GetDailyPenaltyFree()
        {
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            List<DateTime> holiday = new List<DateTime>();
            foreach (string s in sAll.AllKeys)
            {
                holiday.Add(Convert.ToDateTime(sAll.Get(s)));
                Console.WriteLine(Convert.ToDateTime(sAll.Get(s));
            }
            return holiday;
        }
    }
}
