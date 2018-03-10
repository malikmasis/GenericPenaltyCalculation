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
            Console.Write("Başlangıç Tarihi Giriniz:");
            DateTime firstDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Bitiş Tarihi Giriniz:");
            DateTime lastDate = Convert.ToDateTime(Console.ReadLine());

            if(firstDate > lastDate)
            {
                Console.Write("Başlangıç Tarihi Bitiş Tarihinden Büyük Olamaz!");
                return;
            }

            Console.Write("Türkiye için TR İngiltere için EN  yazınız:");
            string country = Console.ReadLine();
            
            if(country != "TR" &&country != "EN")
            {
                Console.Write("Türkiye için TR İngiltere için EN  yazınız:");
                return;
            }
            int penaltDay = BusinessLogic.BusinessDaysUntil(firstDate, lastDate, GetHoliday());
            decimal penatlyAmnount = penaltDay * GetCountryAmount(country);

            Console.Write("Toplam Ceza Günü {0} \nToplam Ceza: {1}",penaltDay,penatlyAmnount);
            Console.ReadKey();

        }

        private static List<DateTime> GetHoliday()
        {
            NameValueCollection sAll = (NameValueCollection)ConfigurationManager.GetSection("Holiday");
            List<DateTime> holiday = new List<DateTime>();
            foreach (string s in sAll.AllKeys)
            {
                holiday.Add(Convert.ToDateTime(sAll.Get(s)));
                //Console.WriteLine(Convert.ToDateTime(sAll.Get(s)));
            }
            return holiday;
        }

        private static int GetCountryAmount(string country)
        {

            NameValueCollection sCountry = (NameValueCollection)ConfigurationManager.GetSection("Country");
            int penaltyAmount = 0;
            //List<int> country = new List<int>();
            penaltyAmount = (Convert.ToInt32(sCountry.Get(country)));
            return penaltyAmount;
        }

    }
}
