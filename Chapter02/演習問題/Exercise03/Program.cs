using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"data\sales.csv");

            Console.WriteLine("＊＊売上集計＊＊");
            Console.WriteLine("１．店舗別売上げ");
            Console.WriteLine("２．商品カテゴリー別売上げ");

            String num = Console.ReadLine();

            switch(num) {
                case "1":
                    var amountPerStore = sales.GetPerStoreSales();
                    foreach(var obj in amountPerStore) {
                        Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
                    }
                    break;

                case "2":
                var amountPerCategory = sales.GetPerCategorySales();
                foreach(var obj in amountPerCategory) {
                    Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
                }
                    break;
            }


            
        }
    }
}
