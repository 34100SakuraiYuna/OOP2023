using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5,4, 0, 4, 1, 0, 4 };
            Console.WriteLine(numbers.Average());
            Console.WriteLine();


            var books = Books.GetBooks();
            
            
            Console.WriteLine(books.Average(i=> i.Price));  //金額の平均
            Console.WriteLine();


            Console.WriteLine(books.Max(i => i.Price));     //最も高い金額
            Console.WriteLine();


            //500円以上本のタイトル&金額
            var booksObj = books.Where(i => i.Price >= 500).OrderByDescending(i => i.Price);
            foreach(var book in booksObj) {
                Console.WriteLine("{0}:{1}円",book.Title,book.Pages);
            }
            Console.WriteLine();


            //「物語」が含まれる本のタイトル&金額
            booksObj = books.Where(i => i.Title.Contains("物語")).OrderByDescending(i => i.Price);
            foreach(var book in booksObj) {
                Console.WriteLine("{0}:{1}円", book.Title, book.Pages);
            }
            Console.WriteLine();


            //「物語」が含まれる本の平均ページ数
            var booksOb = books.Where(i => i.Title.Contains("物語")).Average(i => i.Pages);
            Console.WriteLine("平均：{0}ページ",booksOb);
            Console.WriteLine();


            //タイトルが長い順
            var  longTitleBooks = books.OrderByDescending(i => i.Title.Length);
            foreach(var book in longTitleBooks) {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine();

        }
    }
}
