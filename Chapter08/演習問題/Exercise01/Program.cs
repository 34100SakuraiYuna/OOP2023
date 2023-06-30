using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var dateTime = new DateTime(2019, 1, 15, 19, 48, 32);
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            var str = dateTime.ToString("yyyy/M/d HH:mm");

            Console.WriteLine(str);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            var str2 = dateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒");

            Console.WriteLine(str2);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            var str = dateTime.ToString("ggyy年 M月d日(" + dayOfWeek + ")", culture);

            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {

        }
    }
}
