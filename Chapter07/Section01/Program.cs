using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            #region 花の登録
            //var flowerDict = new Dictionary<string, int>() {
            //    ["sunflower"] = 400,
            //    ["pansy"] = 300,
            //    ["tulip"] = 350,
            //    ["rose"] = 500,
            //    ["dahlia"] = 450,
            //};


            ////朝顔を追加
            //flowerDict["morning glory"] = 250;


            //Console.WriteLine("ひまわりの価格は{0}円です。",flowerDict["sunflower"]);
            //Console.WriteLine("チューリップの価格は{0}円です。", flowerDict["tulip"]);
            //Console.WriteLine("あさがおの価格は{0}円です。", flowerDict["morning glory"]);
            #endregion


            #region 県庁所在地の登録
            var prefectureDict = new Dictionary<string, string>();
            var prefecture = "";
            var prefecturalCapital = "";
            var ans = "";


            Console.WriteLine("県庁所在地の登録");
            Console.Write("県名：");
            prefecture = Console.ReadLine();

            while(prefecture != "999") {
                if(prefectureDict.ContainsKey(prefecture)) {
                    Console.WriteLine("すでに登録済みですが、再登録しますか？");
                    Console.Write("yes/no：");
                    ans = Console.ReadLine();
                    if(ans == "no") {
                        Console.Write("県名：");
                        prefecture = Console.ReadLine();
                        continue;
                    }
                }

                Console.Write("所在地：");
                prefecturalCapital = Console.ReadLine();
                prefectureDict[prefecture] = prefecturalCapital;
                Console.Write("県名：");
                prefecture = Console.ReadLine();
            }

            Console.WriteLine("1：一覧表示　　2：県名指定");
            Console.Write("表示形式：");
            ans = Console.ReadLine();

            while(ans != "1" && ans != "2") {
                Console.WriteLine("1or2を入力してください");
                Console.WriteLine("1：一覧表示　　2：県名指定");
                Console.Write("表示形式：");
                ans = Console.ReadLine();
            }
            if(ans == "1") {
                foreach(var i in prefectureDict) {
                    Console.WriteLine("{0}({1})",i.Key, i.Value);
                }
            } else { 
                Console.Write("県名を入力：");
                prefecture = Console.ReadLine();
                Console.WriteLine("{0}です", prefectureDict[prefecture]);
            }
            #endregion

            #region 県庁所在地の登録(模範解答)
            //var prefOfficeDict = new Dictionary<string, string>();
            //string pref, city;


            //Console.WriteLine("県庁所在地の登録");

            //while(true) {
            //    Console.Write("県名：");
            //    pref = Console.ReadLine();
            //    if(pref == "999")break;
            //    Console.Write("所在地：");
            //    city = Console.ReadLine();

            //    if(prefOfficeDict.ContainsKey(pref)) {
            //        Console.WriteLine("すでに県名が登録されています。");
            //        Console.Write("上書きしますか？(y,n)：");
            //        if(Console.ReadLine() != "y") {
            //            continue;
            //        }
            //    }
            //    prefOfficeDict[pref] = city;
            //}


            //Console.WriteLine();
            //Console.WriteLine("1:一覧表示,2:県名指定");
            //Console.Write("＞");
            //var selected = Console.ReadLine();

            //if(selected == "1") {
            //    foreach(var item in prefOfficeDict) {
            //        Console.WriteLine("{0}({1})", item.Key, item.Value);
            //    }
            //} else { 
            //    Console.Write("県名を入力：");
            //    var inputPref = Console.ReadLine();
            //    Console.WriteLine("{0}です", prefOfficeDict[inputPref]);
            //}
            #endregion
        }
    }


    class CityInfo {
            string City { get; set; }
            int Population { get; set; }
    }
}