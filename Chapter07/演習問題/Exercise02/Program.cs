//using Section03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var abbrs = new Abbreviations();

            //Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");


            //7.2.3(Countプロパティの呼び出し)
            int count = abbrs.Count;
            Console.WriteLine(count);
                //模範解答
                //Console.WriteLine(abbrs.Count);


            //7.2.3(Removeの呼び出し)
            abbrs.Remove("");


            //7.2.4
            //IEnumerable<>を実装したのでLINQが使える
            abbrs.print();
        }
    }
}
