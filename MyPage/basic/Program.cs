using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic {
    class Program {
        static void Main(string[] args) {
            int number = 1234567890;
            string word = "1234567890";

            #region intをstringに変換
            string s = number.ToString();
            #endregion

            #region stringをintに変換
            int i = int.Parse(word);
            #endregion

            #region 画面に表示する
            Console.WriteLine("あいうえお" + 12);
            #endregion

            #region intを画面から入力
            int num = int.Parse(Console.ReadLine());
            #endregion

            #region stringを画面から入力
            string str = Console.ReadLine();
            #endregion

        }
    }
}
