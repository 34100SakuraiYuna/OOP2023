using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {
            var sales = new List<Student>();
            var lines = File.ReadAllLines(filePath);       //ファイルからすべてのデータを読み込む

            foreach(var line in lines){                      //すべての行から一行ずつ取り出す
                var items = line.Split(',');               //区切りで項目別に分ける
                var sale = new Student{                            //Saleインスタンスを生成
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                sales.Add(sale);                                //Saleインスタンスをコレクションに追加
            }
            return sales;
        }


        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new SortedDictionary<string, int>();
            foreach(var sale in _score) {
                if(dict.ContainsKey(sale.Subject))
                    dict[sale.Subject] += sale.Score;  //店名が既に存在する（売り上げ加算）
                else
                    dict[sale.Subject] = sale.Score;  //店名が存在しない（新規格納）
            }
            return dict;
        }
    }
}
