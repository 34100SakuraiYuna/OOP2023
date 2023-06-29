using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text);
            Console.WriteLine();
           // Exercise1_2(text);
        }


        private static void Exercise1_1(string text) {
            #region　自分でやった
            var dict = new Dictionary<Char, int>();
            foreach(var c in text.ToUpper()) {
                if('A' <= c && c <= 'Z') {
                    if(dict.ContainsKey(c)) {
                        dict[c]++;
                    } else {
                        dict[c] = 1;
                    }
                }
            }

            foreach(var item in dict.OrderBy(i=> i.Key)) {
                Console.WriteLine("'{0}'：{1}",item.Key,item.Value);
            }
            #endregion

            #region　模範解答
            //var dict = new Dictionary<Char, int>();
            //foreach(var c in text) {
            //    var uc = char.ToUpper(c);
            //    if('A' <= uc && uc <= 'Z') {
            //        if(dict.ContainsKey(uc)) {
            //            dict[c]++;
            //        } else {
            //            dict[c] = 1;
            //        }
            //    }
            //}

            //foreach(var item in dict.OrderBy(c => c.Key)) {
            //    Console.WriteLine("{0}：{1}", item.Key, item.Value);
            //}
            #endregion
        }

        // private static void Exercise1_2(string text) {

        //}



    }
}


