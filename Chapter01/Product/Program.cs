using System;
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
            #endregion


            DateTime date = new DateTime(2023,5,8);
            DateTime today = DateTime.Today;


            //10日後を求める
            DateTime daysAfter10 = date.AddDays(10);
            DateTime daysBefore10 = date.AddDays(-10);

            Console.WriteLine("今日の日付：" + today);
            Console.WriteLine("１０日後　：" + daysAfter10);
            Console.WriteLine("１０日前　：" + daysBefore10);

        }
    }
}
