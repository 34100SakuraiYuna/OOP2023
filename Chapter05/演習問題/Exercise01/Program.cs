﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Console.Write("文字列１：");
            var str1 = Console.ReadLine();
            Console.Write("文字列１：");
            var str2 = Console.ReadLine();

            if(String.Compare(str1, str2, ignoreCase: true) == 0) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }
}
