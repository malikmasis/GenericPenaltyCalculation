using System;
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

            Console.WriteLine("Türkiye için TR İngiltere için EN  yazınız:");
            string country = Console.ReadLine();
            Console.ReadKey();

            int penaltDay = BusinessLogic.BusinessDaysUntil(firstDate, lastDate, GetHoliday());
            //decimal penatlyAmnount = penaltDay * country;
            
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

        private static int GetCountryAmount(string country)
        {

            NameValueCollection sAll = (NameValueCollection)ConfigurationManager.GetSection("Country");
            int penaltyAmount = 0;
            //List<int> country = new List<int>();
           
                penaltyAmount = (Convert.ToInt32(sAll.GetKey(country)));
                //Console.WriteLine(Convert.ToInt32(sAll.Get(s)));
            
            return penaltyAmount;
        }

    }
}
