using System;
using System.Collections.Generic;

namespace LibraryBusiness
{
    public class BusinessLogic
    {
        public static int BusinessDaysUntil(DateTime firstDay, DateTime lastDay, List<DateTime> bankHolidays)
        {
            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            if (firstDay > lastDay )
                throw new ArgumentException("Incorrect last day " + lastDay);

            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            // Hafta sonu geçip geçmediği kontrol ediliyor.
            if (businessDays > fullWeekCount * 7)
            {
                //hafta sonları çıkarıldıktan sonra
                int firstDayOfWeek = (int)firstDay.DayOfWeek;
                int lastDayOfWeek = (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// c.tesi pazar birlikte ise 
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)// sadece c.tesi
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// sadece pazar
                    businessDays -= 1;
            }

            // aradaki hafta sonları çıkarılır
            businessDays -= fullWeekCount + fullWeekCount;

            // app cofigden okunan günler çıkarılır
            foreach (DateTime bankHoliday in bankHolidays)
            {
                DateTime bh = bankHoliday.Date;
                if (firstDay <= bh && bh <= lastDay)
                    --businessDays;
            }
            //toplam ceza günü döner
            return businessDays;
        }

    }
    
   
}
