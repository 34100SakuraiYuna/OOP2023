using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            var str = dateTime.ToString("yyyy/M/d HH:mm");
            //模範解答
            //var str = string.Format("{0:yyyy/M/d HH:mm}",dateTime);

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

            var str3 = dateTime.ToString("ggyy年 M月d日(" + dayOfWeek + ")", culture);
            //模範解答
            //var datestr = dateTime.ToString("ggyy",culture);
            //str3 = string.Format("{0}年{1,2}月{2,2}日({3})",datestr,dateTime.Month,dateTime.Day,dateTime.DayOfWeek);

            Console.WriteLine(str3);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dateStr = dateTime.ToString("ggyy年MM月dd日(dddd)", culture);
            var str = Regex.Replace(dateStr,@"0(\d)","$1");
            Console.WriteLine(str);
        }
    }
}
