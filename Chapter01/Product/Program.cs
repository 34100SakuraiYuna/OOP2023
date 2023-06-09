﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {

    class Program {
        static void Main(string[] args) {
            #region　P26のサンプルプログラム
            ////インスタンスの生成（インスタンス = オブジェクト）
            //Product karintou = new Product(123,"かりんとう",180);
            //Product daihuku = new Product(235, "大福もち", 160);

            //Console.WriteLine("かりんとうの税込価格：" + karintou.GetPriceIncludingtax() + "円");
            //Console.WriteLine("大福もちの税込価格：" + daihuku.GetPriceIncludingtax() + "円");
            //DateTime date = new DateTime(2023,5,8);
            #endregion


            #region 今日の日付と前後10日(演習1)
            //DateTime today = DateTime.Today;            //今日
            //DateTime daysAfter10 = today.AddDays(10);   //10日後
            //DateTime daysBefore10 = today.AddDays(-10); //10日前

            //Console.WriteLine("今日の日付：" + today.ToString("yyyy年MM月dd日"));
            //Console.WriteLine("１０日後　：" + daysAfter10.ToString("yyyy年MM月dd日"));
            //Console.WriteLine("１０日前　：" + daysBefore10.ToString("yyyy年MM月dd日"));
            #endregion


            #region 生まれてから何日経過したか（演習2）
            //int year;
            //int month;
            //int day;
            //DateTime today = DateTime.Today;            //今日


            //Console.WriteLine("誕生日を入力");
            //Console.Write("西暦：");
            //year = int.Parse(Console.ReadLine());
            //Console.Write("月　：");
            //month = int.Parse(Console.ReadLine());
            //Console.Write("日　：");
            //day = int.Parse(Console.ReadLine());

            //DateTime birthday = new DateTime(year,month,day);
            //// TimeSpan interval = new TimeSpan(birthday);
            //TimeSpan interval = today - birthday;

            //Console.WriteLine("あなたは生まれてから今日まで" + interval.Days+ "日目です。");
            #endregion


            #region 何曜日に生まれたか（演習3）
            int year;
            int month;
            int day;


            Console.WriteLine("誕生日を入力");
            Console.Write("西暦：");
            year = int.Parse(Console.ReadLine());
            Console.Write("月　：");
            month = int.Parse(Console.ReadLine());
            Console.Write("日　：");
            day = int.Parse(Console.ReadLine());

            DateTime birthday = new DateTime(year, month, day);

            Console.WriteLine("あなたは" + birthday.ToString("dddd") + "に生まれました。");
            #endregion
        }
    }
}
