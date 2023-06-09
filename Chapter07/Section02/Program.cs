﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            #region 都市の登録
            var prefectureDict = new Dictionary<string, List<CityInfo>>();
            string prefecture, city, ans;
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


            //表示形式の指定
            Console.WriteLine("1：一覧表示　　2：県名指定");
            Console.Write("表示形式：");
            ans = Console.ReadLine();

            //１，２以外を指定された時の処理
            while(ans != "1" && ans != "2") {
                Console.WriteLine("1or2を入力してください");
                Console.WriteLine("1：一覧表示　　2：県名指定");
                Console.Write("表示形式：");
                ans = Console.ReadLine();
            }

            if(ans == "1") {
                //一覧表示
                foreach(var pref in prefectureDict) {
                    foreach(var j in pref.Value) {
                        Console.WriteLine("{0}[{1}(人口：{2})]", pref.Key, j.City, j.Population);
                    }
                }
            } else {
                //県名指定表示
                Console.Write("県名を入力：");
                prefecture = Console.ReadLine();

                while(true) {
                    if(prefectureDict.ContainsKey(prefecture)) {
                        foreach(var pref in prefectureDict) {
                            if(pref.Key.Equals(prefecture)) {
                                foreach(var j in pref.Value) {
                                    Console.WriteLine("[{0}(人口：{1})]", j.City, j.Population);
                                }
                            }
                        }
                        break;
                    } else {
                        //登録済みの都道府県以外を入力された場合
                        Console.WriteLine("登録済みの都道府県から入力してください");
                        Console.Write("県名を入力：");
                        prefecture = Console.ReadLine();
                    }
                }
            }
            #endregion

            #region 都市の登録(模範解答)
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

            //    //市町村情報のインスタンスの生成
            //    var cityInfo = new CityInfo {
            //        City = city,
            //        Population = population,
            //    };


            //    //県名が未登録かの確認
            //    if(!prefDict.ContainsKey(pref)) {
            //        //List<CityInfo>(県名)が存在しないためListをnew(作成)する
            //        prefDict[pref] = new List<CityInfo> { cityInfo };
            //    }

            //    //市町村データを追加
            //    prefDict[pref].Add(cityInfo);
            //}


            //Console.WriteLine();
            //Console.WriteLine("1:一覧表示,2:県名指定");
            //Console.Write("＞");
            //var selected = Console.ReadLine();

            //if(selected == "1") {
            //    //一覧表示
            //    foreach(var prefData in prefDict) {
            //        foreach(var cityData in prefData.Value) {
            //            Console.WriteLine("{0}[{1}(人口：{2}人)]", prefData.Key, cityData.City, cityData.Population);
            //        }
            //    }
            //} else {
            //    //県名指定表示
            //    Console.Write("県名を入力：");
            //    var inputPref = Console.ReadLine();
            //    foreach(var cityData in prefDict[inputPref]) {
            //        Console.WriteLine("{0}[{1}(人口：{2}人)]", inputPref, cityData.City, cityData.Population);
            //    }
            //}
            #endregion
        }
    }


    class CityInfo {
        public string City { get; set; }       //都市（県庁所在地）
        public int Population { get; set; }    //人口
    }
}
