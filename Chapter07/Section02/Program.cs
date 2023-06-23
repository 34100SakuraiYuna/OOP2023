using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {

            #region 都市の登録
            var cityList = new List<CityInfo>();
            var prefectureDict = new Dictionary<string, List<CityInfo>>();
            var prefecture = "";
            var city = "";
            var ans = "";
            var population = 0;


            Console.WriteLine("都市の登録");
            Console.Write("県名：");
            prefecture = Console.ReadLine();

            //再登録の確認
            while(prefecture != "999") {
                if(prefectureDict.ContainsKey(prefecture)) {
                    Console.WriteLine("すでに登録済みですが、追加登録しますか？");
                    Console.Write("yes/no：");
                    ans = Console.ReadLine();
                    if(ans == "no") {
                        Console.Write("県名：");
                        prefecture = Console.ReadLine();
                        continue;
                    }
                }

                //都市の登録
                var cityInfo = new CityInfo();

                Console.Write("都市：");
                city = Console.ReadLine();
                cityInfo.City = city;
                Console.Write("人口：");
                population = int.Parse(Console.ReadLine());
                cityInfo.Population = population;

                cityList.Add(cityInfo);

                prefectureDict[prefecture] = cityList;


                Console.Write("県名：");
                prefecture = Console.ReadLine();
            }

            //並べ替え
           // var orderByDisc = prefectureDict.OrderByDescending(i => i.Value.Population);


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
                foreach(var i in prefectureDict) {

                    Console.WriteLine("{0}[{1}(人口：)]", i.Key, i.Value);
                }
            } else {
                Console.Write("県名を入力：");
                prefecture = Console.ReadLine();
                Console.WriteLine("県庁所在地は{0}で、人口{1}人です", prefectureDict[prefecture][0], prefectureDict[prefecture][1]);
            }
            #endregion


        }
    }

    class CityInfo {
        public string City { get; set; }       //都市（県庁所在地）
        public int Population { get; set; }    //人口
    }

}
