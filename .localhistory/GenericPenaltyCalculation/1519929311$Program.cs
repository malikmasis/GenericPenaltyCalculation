﻿using System;
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
        }

        private List<DateTime> GetDailyPenaltyFree()
        {
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            List<DateTime> holiday = new List<DateTime>();
            foreach (string s in sAll.AllKeys)
            {
                holiday.Add(s);
            }
            //Console.WriteLine("Key: " + s + " Value: " + sAll.Get(s));
            //Console.ReadLine();
            return holiday;
        }
    }
}
