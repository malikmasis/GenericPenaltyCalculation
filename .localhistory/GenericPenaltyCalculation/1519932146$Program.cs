﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading.Tasks;

using LibraryBusiness;
namespace GenericPenaltyCalculation
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Başlangıç Tarihi Giriniz:");
            DateTime firstDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Bitiş Tarihi Giriniz:");
            DateTime lastDate = Convert.ToDateTime(Console.ReadLine());

            if(firstDate > lastDate)
            {
                Console.WriteLine("Başlangıç Tarihi Bitiş Tarihinden Büyük Olamaz!");
                return;
            }

            Console.WriteLine("Türkiye için 1 İngiltere için 2'ye basınız:");
            int country = Convert.ToInt32(Console.ReadLine());
            Console.ReadKey();

            int penaltDay = BusinessLogic.BusinessDaysUntil(firstDate, lastDate, GetHoliday());
            decimal penatlyAmnount = penaltDay * country;
            
        }

        private static List<DateTime> GetHoliday()
        {
            NameValueCollection sAll = (NameValueCollection)ConfigurationManager.GetSection("Holiday");
            List<DateTime> holiday = new List<DateTime>();
            foreach (string s in sAll.AllKeys)
            {
                holiday.Add(Convert.ToDateTime(sAll.Get(s)));
                Console.WriteLine(Convert.ToDateTime(sAll.Get(s)));
            }
            return holiday;
        }

        private static int GetCountryAmount(int country)
        {

            NameValueCollection sAll = (NameValueCollection)ConfigurationManager.GetSection("Country");

            //List<int> country = new List<int>();
            foreach (string s in sAll.AllKeys)
            {
                country.Add(Convert.ToInt32(sAll.Get(s)));
                Console.WriteLine(Convert.ToInt32(sAll.Get(s)));
            }
            return holiday;
        }

    }
}
