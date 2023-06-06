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


            var books = Books.GetBooks();


            Console.WriteLine(books.Average(i=> i.Price));  //金額の平均

            Console.WriteLine(books.Max(i => i.Price));     //最も高い金額
            
            //500円以上本のタイトル&金額
            var booksObj = books.Where(i => i.Price >= 500).OrderByDescending(i => i.Price);
            foreach(var book in booksObj) {
                Console.WriteLine("{0}:{1}円",book.Title,book.Pages);
                Console.WriteLine();
            }

            //「物語」が含まれる本のタイトル&金額
            var booksOb = books.Where(i => i.Title.Contains("物語")).OrderByDescending(i => i.Price);
            foreach(var book in booksOb) {
                Console.WriteLine("{0}:{1}円", book.Title, book.Pages);
            }
        }
    }
}
