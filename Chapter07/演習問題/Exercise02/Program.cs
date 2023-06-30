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
            abbrs.Remove("NPT");
            //模範解答
            //if(abbrs.Remove("NPT")) {
            //    Console.WriteLine(abbrs.Count);
            //}
            //if(!abbrs.Remove("NPT")) {
            //    Console.WriteLine("削除できません");
            //}


            //7.2.4
            //IEnumerable<>を実装したのでLINQが使える
            abbrs.print();
                //模範解答
                //foreach(var item in abbrs.Where(abb => abb.Key.Length == 3)) {
                //    Console.WriteLine("{0}={1}", item.Key, item.Value);
                //}
        }
    }
}