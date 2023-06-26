using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {

            #region 都市の登録
            var prefectureDict = new Dictionary<string, List<CityInfo>>();
            string prefecture,city,ans;
            int population;
            List<CityInfo> list;


            Console.WriteLine("都市の登録");
            Console.Write("県名：");
            prefecture = Console.ReadLine();

            while(prefecture != "999") {
                Console.Write("市区町村：");
                city = Console.ReadLine();
                Console.Write("人口：");
                population = int.Parse(Console.ReadLine());

                CityInfo cityInfo = new CityInfo {
                    City = city,
                    Population = population,
                };


                if(prefectureDict.ContainsKey(prefecture)) {
                    list = prefectureDict[prefecture];
                    list.Add(cityInfo);
                
                } else {
                    list = new List<CityInfo>();
                    list.Add(cityInfo);
                    prefectureDict[prefecture] = list;
                }
                Console.Write("県名：");
                prefecture = Console.ReadLine();
            }


















            //表示形式
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
                foreach(var pref in prefectureDict) {
                    foreach(var j in pref.Value) {
                        Console.WriteLine("{0}[{1}(人口：{2})]", pref.Key, j.City, j.Population);
                    }
                }
            } else {
                Console.Write("県名を入力：");
                prefecture = Console.ReadLine();

                foreach(var j in prefectureDict[prefecture]) {
                    Console.WriteLine("{0}[{1}(人口：{2})]", j.City, j.Population);
                }


            }
            #endregion


            #region 県庁所在地の登録(模範解答)
            //var prefDict = new Dictionary<string, List<CityInfo>>();
            //string pref, city;
            //int population;


            //Console.WriteLine("県庁所在地の登録");

            //while(true) {
            //    Console.Write("県名：");
            //    pref = Console.ReadLine();
            //    if(pref == "999") break;
            //    Console.Write("市町村：");
            //    city = Console.ReadLine();
            //    Console.Write("人口：");
            //    population = int.Parse(Console.ReadLine());

            //    //既に県名が登録されているか
            //    if(prefDict.ContainsKey(pref)) {

            //    } else { 
                
            //    }

            //    //登録処理
            //    prefDict[pref] = new CityInfo {
            //        City = city,
            //        Population = population,
            //    };
            //}


            //Console.WriteLine();
            //Console.WriteLine("1:一覧表示,2:県名指定");
            //Console.Write("＞");
            //var selected = Console.ReadLine();

            //if(selected == "1") {
            //    //一覧表示
            //    foreach(var item in prefOfficeDict.OrderByDescending(p => p.Value.population)) {
            //        Console.WriteLine("{0}[{1}(人口：{2}人)]", item.Key, item.Value.City, item.Value.Population);
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
