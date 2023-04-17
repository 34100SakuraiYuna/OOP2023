using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {
            Console.Write("合計金額：");
            int sum = int.Parse(Console.ReadLine());
            Console.Write("支払金額：");
            int pay = int.Parse(Console.ReadLine());
            int change = pay - sum;
            Console.WriteLine("お釣り：" + change + "円");

            printChange(change);
        }

        //お釣りを出力
        private static void printChange(int change) {
            int[] integerMoney = { 10000, 5000, 2000, 1000, 500, 100, 50, 10, 5, 1 };//お金
            string[] stringMoney = {"一万円札","五千円札","二千円札","　千円札","五百円玉","　百円玉","五十円玉","　十円玉","　五円玉","　一円玉" };

            for (int i = 0; i < integerMoney.Length; i++){
                //Console.Write(stringMoney[i] + "円：{0}枚",changes[i]);
                Console.Write(stringMoney[i] + "：");
                printAst(change/integerMoney[i]);
                change %= integerMoney[i];
            }
        }

        //＊を出力
        private static void printAst(int count) {
            for (int i = 0; i < count; i++){
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}