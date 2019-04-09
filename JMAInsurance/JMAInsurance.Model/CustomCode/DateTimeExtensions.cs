using System;
using System.Collections.Generic;
using System.Linq;

namespace JMAInsurance.Entity.CustomCode
{
    public static class DateTimeExtensions
    {
        
        /// <summary>
        /// Adds the given number of business days to the <see cref="DateTime"/>.
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime AddBusinessDays(this DateTime current, double days, List<Holiday> Holidays)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                } while (current.DayOfWeek == DayOfWeek.Saturday ||
                         current.DayOfWeek == DayOfWeek.Friday || Holidays.Any(x=>x.From.Date <= current.Date && x.To.Date >= current.Date));
            }
            return current;
        }

        public static int GetWorkingDays(DateTime from, DateTime to, string id)
        {

            if (from >= to) return 0;
          DateTime.TryParse(to.ToShortDateString() ,out to);
            DateTime.TryParse(from.ToShortDateString(), out from);
            var dayDifference = (int)to.Subtract(from).TotalDays;
            dayDifference = dayDifference + 1;
            return Enumerable
                .Range(1, dayDifference)
                .Select(x => from.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Friday);
        }


        public static DateTime AddBusinessHours(this DateTime current, int hours, List<Holiday> Holidays)
        {
            var sign = Math.Sign(hours);
            var unsignedhours = Math.Abs(hours);
            for (var i = 0; i < unsignedhours; i++)
            {
                do
                {
                    current = current.AddHours(sign);
                } while (current.DayOfWeek == DayOfWeek.Saturday ||
                         current.DayOfWeek == DayOfWeek.Friday || 
                         Holidays.Any(x => x.From.Date <= current.Date && x.To.Date >= current.Date) ||
                         current.Hour < 8 ||
                         current.Hour >= 16 );
            }
            return current;
        }
        

        /// <summary>
        /// Determine if a <see cref="DateTime"/> is in the future.
        /// </summary>
        /// <param name="dateTime">The date to be checked.</param>
        /// <returns><c>true</c> if <paramref name="dateTime"/> is in the future; otherwise <c>false</c>.</returns>
        
    }
}
