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

        #region 空白で区切って配列に格納する Split
        private static void textSprit(string text) {
            string[] array = text.Split(' ').ToArray();
        }
        #endregion

        #region 配列に含まれる文字を探して、要素番号を返す IndexOf
        private static void takeArrayNumber() {
            string[] lines = { "Novelist","谷崎潤一郎","BestWork","春琴抄","Born","1886" };
            
            Console.WriteLine("作家：{0}", lines[(Array.IndexOf(lines, "Novelist")) + 1]);
            //Array.IndexOf(探したい配列名, "探したい文字")
        }
        #endregion

        #region LINQ リストから条件を満たすものを抽出する
        class Book {
            public string Title { get; set; }
            public int Price { get; set; }
            public int Pages { get; set; }
        }

        private static void r() {
            var books = new List<Book> {
               new Book { Title = "こころ", Price = 400, Pages = 378 },
               new Book { Title = "人間失格", Price = 281, Pages = 212 },
            };


            //最も高い金額
            Console.WriteLine(books.Max(i => i.Price));     
            Console.WriteLine();


            //「物語」が含まれる本の平均ページ数
            var booksOb = books.Where(i => i.Title.Contains("物語")).Average(i => i.Pages);
            Console.WriteLine("平均：{0}ページ", booksOb);
            Console.WriteLine();


            //1000円以下でタイトルが長い順
            var longTitleBooks = books.Where(i=> i.Price<=1000).OrderByDescending(i => i.Title.Length);
            foreach(var book in longTitleBooks) {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine();
        }
        #endregion



    }
}
