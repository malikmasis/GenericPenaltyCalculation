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
            GetHoliday();
            GetCountry();
            Console.ReadKey();
        }

        private static void GetHoliday()
        {
            NameValueCollection sAll = (NameValueCollection)ConfigurationManager.GetSection("Holiday");


            List<DateTime> holiday = new List<DateTime>();
            foreach (string s in sAll.AllKeys)
            {
                holiday.Add(Convert.ToDateTime(sAll.Get(s)));
                Console.WriteLine(Convert.ToDateTime(sAll.Get(s)));
            }
            //return holiday;
        }

        private static void GetCountry()
        {

            NameValueCollection sAll = (NameValueCollection)ConfigurationManager.GetSection("Country");

            List<int> country = new List<int>();
            foreach (string s in sAll.AllKeys)
            {
                country.Add(Convert.ToInt32(sAll.Get(s)));
                Console.WriteLine(Convert.ToInt32(sAll.Get(s)));
            }
            //return holiday;
        }

    }
}
