using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var line = "NNovelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var infos = line.Split(';','=').ToArray() ;

            Console.WriteLine("作家：{0}",infos[1]);
            Console.WriteLine("代表作：{0}", infos[3]);
            Console.WriteLine("誕生年：{0}", infos[5]);

        }
    }
}
