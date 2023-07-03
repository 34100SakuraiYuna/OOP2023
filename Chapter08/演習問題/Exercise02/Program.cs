using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var day = DateTime.Today;
            DateTime next;
            string dayOfWeek;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();


            foreach(DayOfWeek dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                next = NextDay(day, dayofweek);
                dayOfWeek = culture.DateTimeFormat.GetDayName(next.DayOfWeek);

                Console.WriteLine("{0}の次週の{1}：{2}({3})", day.ToString("yyyy/MM/dd"), dayofweek, next.ToString("yy/MM/dd"), dayOfWeek);
            }
        }

        public static DateTime NextDay(DateTime date,DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
                days += 7;
            return date.AddDays(days);
        }

    }
}
