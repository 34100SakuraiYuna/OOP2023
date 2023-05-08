using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {

    class Program {
        static void Main(string[] args) {
            //インスタンスの生成（インスタンス = オブジェクト）
            Product karintou = new Product(123,"かりんとう",180);
            Product daihuku = new Product(235, "大福もち", 160);

            Console.WriteLine("かりんとうの税込価格：" + karintou.GetPriceIncludingtax() + "円");
            Console.WriteLine("大福もちの税込価格：" + daihuku.GetPriceIncludingtax() + "円");
        }
    }
}
