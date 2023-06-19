using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        public static IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {


            var dict = new Dictionary<string, int>();
            foreach(var test in _score) {
                if(dict.ContainsKey(test.Subject))
                    dict[test.Subject] += test.Score;  //教科名が既に存在する（点数加算）
                else
                    dict[test.Subject] = test.Score;  //教科名が存在しない（新規格納）
            }


            return (IEnumerable<Student>)dict;

        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {


            var scores = new List<Student>();


         return (IDictionary<string, int>)scores;
        }




        
    }
}
