﻿//#define NonArray
#define StringArray

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {

#if NonArray
            var line = "NNovelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var infos = line.Split(';','=').ToArray() ;

            Console.WriteLine("作家：{0}",infos[1]);
            Console.WriteLine("代表作：{0}", infos[3]);
            Console.WriteLine("誕生年：{0}", infos[5]);

#elif StringArray
            string[] lines = { "NNovelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867", "NNovelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896"};

            foreach(var i in lines) {
                var infos = i.Split('=',';');
                Console.WriteLine("作家：{0}", infos[1]);
                Console.WriteLine("代表作：{0}", infos[3]);
                Console.WriteLine("誕生年：{0}", infos[5]);
            }
#endif
        }
    }
}
