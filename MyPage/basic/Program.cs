using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic {
    class Program {
        static void Main(string[] args) {
            int number1 = 1234567890;
            string word1 = "1234567890";

            #region intをstringに変換
            string word2 = number1.ToString();
            #endregion

            #region stringをintに変換
            int number2 = int.Parse(word1);
            #endregion

            #region 画面に表示する
            Console.WriteLine("あいうえお" + 12);
            #endregion

            #region intを画面から入力
            int numner3 = int.Parse(Console.ReadLine());
            #endregion

            #region stringを画面から入力
            string word3 = Console.ReadLine();
            #endregion

        }
    }
}
