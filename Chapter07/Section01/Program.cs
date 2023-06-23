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


            #region 県庁所在地の登録(ちゃんと動くよ)
            var prefectureDict = new Dictionary<string, CityInfo>();
            var prefecture = "";
            var prefecturalCapital = "";
            var ans = "";
            var population = 0;


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

                var cityInfo = new CityInfo();

                Console.Write("所在地：");
                prefecturalCapital = Console.ReadLine();
                cityInfo.City = prefecturalCapital;
                Console.Write("人口：");
                population = int.Parse(Console.ReadLine());
                cityInfo.Population = population;

                prefectureDict[prefecture] = cityInfo;


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
                    Console.WriteLine("{0}[{1}(人口：{2})]", i.Key, i.Value.City, i.Value.Population);
                }
            } else {
                Console.Write("県名を入力：");
                prefecture = Console.ReadLine();
                Console.WriteLine("県庁所在地は{0}で、人口{1}人です", prefectureDict[prefecture].City, prefectureDict[prefecture].Population);
            }
            #endregion

            #region 県庁所在地の登録(模範解答)
            //var prefOfficeDict = new Dictionary<string, CityInfo>();
            //string pref, city;
            //int population;


            //Console.WriteLine("県庁所在地の登録");

            //while(true) {
            //    Console.Write("県名：");
            //    pref = Console.ReadLine();
            //    if(pref == "999") break;
            //    Console.Write("所在地：");
            //    city = Console.ReadLine();
            //    Console.Write("人口：");
            //    population = int.Parse(Console.ReadLine());

            //    //既に県名が登録されているか
            //    if(prefOfficeDict.ContainsKey(pref)) {
            //        Console.WriteLine("すでに県名が登録されています。");
            //        Console.Write("上書きしますか？(y,n)：");
            //        if(Console.ReadLine() != "y") {
            //            continue;
            //        }
            //    }

            //    //登録処理
            //    prefOfficeDict[pref] = new CityInfo {
            //        City = city,
            //        Population = population,
            //    };
            //}


            //Console.WriteLine();
            //Console.WriteLine("1:一覧表示,2:県名指定");
            //Console.Write("＞");
            //var selected = Console.ReadLine();

            //if(selected == "1") {
            //    foreach(var item in prefOfficeDict) {
            //        Console.WriteLine("{0}[{1}(人口：{2}人)]", item.Key, item.Value.City,item.Value.Population);
            //    }
            //} else {
            //    Console.Write("県名を入力：");
            //    var inputPref = Console.ReadLine();
            //    Console.WriteLine("[{0}(人口：{1}人)]", prefOfficeDict[inputPref].City, prefOfficeDict[inputPref].Population);
            //}
            #endregion
        }
    }


    class CityInfo {
        public string City { get; set; }       //都市（県庁所在地）
        public int Population { get; set; }    //人口
    }
}