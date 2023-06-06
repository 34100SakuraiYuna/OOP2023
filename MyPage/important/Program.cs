using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace important {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz ";

            countSpace(text);
            Console.WriteLine("-----");
            replaceWord(text);
            Console.WriteLine("-----");
            countWords(text);
            Console.WriteLine("-----");
            countWords2(text);
            Console.WriteLine("-----");
            countSpace(text);
            Console.WriteLine("-----");



        }

        #region 空白を数える
        private static void countSpace(string text) {
            int count = text.Count(c => c == ' ');

            Console.WriteLine("空白数：{0}", count);
        }
        #endregion

        #region 単語を別のものに置き換える
        private static void replaceWord(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }
        #endregion

        #region 単語を数える
        private static void countWords(string text) {
            var count = text.Split(' ').Length;
            Console.WriteLine("単語数：{0}", count);
        }
        #endregion

        #region 4文字以下の単語を列挙
        private static void countWords2(string text) {
            var words = text.Split(' ').Where(word => word.Length <= 4);
            foreach(var word in words) {
                Console.WriteLine(word);
            }
        }
        #endregion

        #region 空白(前後のみ)を削除する
        private static void deleteSpace(string text) {
            string str1 = text.Trim();      //前後削除
            string str2 = text.TrimStart(); //前のみ削除
            string str3 = text.TrimEnd();   //後ろのみ削除
            text = text.Trim();             //textそのものを変更する
        }
        #endregion

        #region 空白で区切って配列に格納する
        private static void textSprit(string text) {
            string[] array = text.Split(' ').ToArray();
        }
        #endregion







    }
}
