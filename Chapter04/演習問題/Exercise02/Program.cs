using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            // 4.2.1
            var ymCollection = new Yearmonth[] {
                new Yearmonth(1980, 1),
                new Yearmonth(1990, 4),
                new Yearmonth(2000, 7),
                new Yearmonth(2010, 9),
                new Yearmonth(2020, 12),
            };


            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);
            Console.WriteLine("\n- 4.2.4 ---");


            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("\n- 4.2.5 ---");


            // 4.2.5
            Exercise2_5(ymCollection);
        }


        private static void Exercise2_2(Yearmonth[] ymCollection) {
            foreach(var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }


        static Yearmonth FindFirst21C(Yearmonth[] yms) {
            foreach(var item in yms) {
                if(item.Is12Century) {
                    return item;
                }
            }
            return null;
        }


        private static void Exercise2_4(Yearmonth[] ymCollection) {
            var yearmonth = FindFirst21C(ymCollection);
            if(yearmonth == null) {
                Console.WriteLine("21世紀のデータはありません");
            } else {
                Console.WriteLine(yearmonth);
            }

            //Console.WriteLine(yearmonth == null ? "21世紀のデータはありません" : yearmonth.ToString());

            // Console.WriteLine(yearmonth?.ToString() ?? "21世紀のデータはありません");
        }


        private static void Exercise2_5(Yearmonth[] ymCollection) {
            var array = ymCollection.Select(ym =>  ym.addOneMonth()).ToArray();
            Exercise2_2(array);
        }
    }
}
