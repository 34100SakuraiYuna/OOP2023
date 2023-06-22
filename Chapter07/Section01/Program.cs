using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            #region 花の登録
            var flowerDict = new Dictionary<string, int>() {
                ["sunflower"] = 400,
                ["pansy"] = 300,
                ["tulip"] = 350,
                ["rose"] = 500,
                ["dahlia"] = 450,
            };


            //朝顔を追加
            flowerDict["morning glory"] = 250;


            Console.WriteLine("ひまわりの価格は{0}円です。",flowerDict["sunflower"]);
            Console.WriteLine("チューリップの価格は{0}円です。", flowerDict["tulip"]);
            Console.WriteLine("あさがおの価格は{0}円です。", flowerDict["morning glory"]);
            #endregion



            var prefectureDict = new Dictionary<string, string>();
            var prefecture = "";
            var prefecturalCapital = "";


            Console.WriteLine("県庁所在地の登録");


            Console.Write("県名：");
            prefecture = Console.ReadLine();

            while(prefecture != "999") {
                Console.Write("所在地：");
                prefecturalCapital = Console.ReadLine();
                prefectureDict[prefecture] = prefecturalCapital;
                Console.Write("県名：");
                prefecture = Console.ReadLine();
            }

            Console.Write("県名を入力：");
            prefecture = Console.ReadLine();
            Console.WriteLine("{0}です", prefectureDict[prefecture]);
        }
    }
}