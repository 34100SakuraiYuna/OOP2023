using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace important {
    class Program {
        static void Main(string[] args) {
            var text1 = "Jackdaws love my big sphinx of quartz ";

            countSpace(text1);
            Console.WriteLine("-----");
            replaceWord(text1);
            Console.WriteLine("-----");
            countWords(text1);
            Console.WriteLine("-----");
            countWords2(text1);
            Console.WriteLine("-----");
            countSpace(text1);
            Console.WriteLine("-----");
            printDayOfWeek();
            Console.WriteLine("-----");
            getGengo();
            Console.WriteLine("-----");
        }

        #region 空白を数える
        private static void countSpace(string text1) {
            int count1 = text1.Count(c => c == ' ');

            Console.WriteLine("空白数：{0}", count1);
        }
        #endregion

        #region 単語を別のものに置き換える
        private static void replaceWord(string text1) {
            Console.WriteLine(text1.Replace("big", "small"));
        }
        #endregion

        #region 単語を数える
        private static void countWords(string text1) {
            var count2 = text1.Split(' ').Length;
            Console.WriteLine("単語数：{0}", count2);
        }
        #endregion

        #region 4文字以下の単語を列挙
        private static void countWords2(string text1) {
            var words1 = text1.Split(' ').Where(word1 => word1.Length <= 4);
            foreach(var word1 in words1) {
                Console.WriteLine(word1);
            }
        }
        #endregion

        #region 空白(前後のみ)を削除する
        private static void deleteSpace(string text1) {
            string str1 = text1.Trim();      //前後削除
            string str2 = text1.TrimStart(); //前のみ削除
            string str3 = text1.TrimEnd();   //後ろのみ削除
            text1 = text1.Trim();             //textそのものを変更する
        }
        #endregion

        #region 空白で区切って配列に格納する Split
        private static void textSprit(string text1) {
            string[] array = text1.Split(' ').ToArray();
        }
        #endregion

        #region 配列に含まれる文字を探して、要素番号を返す IndexOf
        private static void takeArrayNumber() {
            string[] infomations = { "Novelist","谷崎潤一郎","BestWork","春琴抄","Born","1886" };
            
            Console.WriteLine("作家：{0}", infomations[(Array.IndexOf(infomations, "Novelist")) + 1]);
            //Array.IndexOf(探したい配列名, "探したい文字")
        }
        #endregion

        #region LINQ リストから条件を満たすものを抽出する
        class Book {
            public string Title { get; set; }
            public int Price { get; set; }
            public int Pages { get; set; }
        }

        private static void linqEtc() {
            var books = new List<Book> {
               new Book { Title = "こころ", Price = 400, Pages = 378 },
               new Book { Title = "人間失格", Price = 281, Pages = 212 },
            };


            //最も高い金額
            Console.WriteLine(books.Max(i => i.Price));     
            Console.WriteLine();


            //「物語」が含まれる本の平均ページ数
            var booksObject = books.Where(i => i.Title.Contains("物語")).Average(i => i.Pages);
            Console.WriteLine("平均：{0}ページ", booksObject);
            Console.WriteLine();


            //1000円以下でタイトルが長い順
            var longTitleBooks = books.Where(i=> i.Price<=1000).OrderByDescending(i => i.Title.Length);
            foreach(var book in longTitleBooks) {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine();
        }
        #endregion

        #region タイマー　Stopwatch
        private static void stopWatch() {
            //using System.Diagnosticsを忘れないように
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            //ここに処理内容

            Console.WriteLine("実行時間：{0}",sw.Elapsed.ToString(@"ss\.fffff"));
        }
        #endregion

        #region LINQ リストから条件を満たす最初のものを返す
        class Book2 {
            public string Title { get; set; }
            public int Price { get; set; }
            public int Pages { get; set; }
        }


        List<Book2> books30 = new List<Book2> {
               new Book2 { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book2 { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book2 { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };


        private static void fastOnly(List<Book2> books30) {
            var book = books30.FirstOrDefault(i => i.Price >= 4000);
            if(book != null) {
                Console.WriteLine(book.Title);
            }
        }
        #endregion

        #region 曜日を日本語にする
        private static void printDayOfWeek() {
            var date = new DateTime(2003,4,30);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);

            Console.WriteLine(dayOfWeek);
        }
        #endregion

        #region 元号(平成とか)を出す
        private static void getGengo() {
            var date = new DateTime(2003, 4, 30);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(date);
            var eraName = culture.DateTimeFormat.GetEraName(era);

            Console.WriteLine(eraName);
            Console.WriteLine(date.ToString("gyy年M月d日",culture));
        }
        #endregion
    }
}

