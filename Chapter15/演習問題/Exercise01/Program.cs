using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }


        private static void Exercise1_2() {
            var maxPrice = Library.Books.Max(b => b.Price);
            var book = Library.Books
                  .First(b => b.Price == maxPrice);
            Console.WriteLine(book);

            //模範解答
            //var max = Library.Books.Max(b => b.Price);
            //var books = Library.Books.Where(b => b.Price == max);
            //foreach(var book in books) {
            //    Console.WriteLine(book);
            //}
        }


        private static void Exercise1_3() {
            var groups = Library.Books.GroupBy(b => b.PublishedYear).OrderBy(g => g.Key);
            foreach(var g in groups) {
                Console.Write($"{g.Key}年");
                var count = 0;

                foreach(var book in g) {
                    count++;
                }
                Console.WriteLine("　{0}冊",count);
            }
        }


        private static void Exercise1_4() {
            var groups = Library.Books.OrderByDescending(b => b.PublishedYear).OrderByDescending(b => b.Price);
            var categorys = Library.Categories.ToList();
            foreach(var g in groups) {
                Console.WriteLine("{0}年　{1}円　{2}　({3})"
                    ,g.PublishedYear,g.Price,g.Title,categorys[(g.CategoryId)-1].Name);
            }
        }


        private static void Exercise1_5() {
            var lookup = Library.Books.ToLookup(b => b.PublishedYear);
            var books = lookup[2016];
            var categorys = Library.Categories.Select(c=> c.Name).ToList();

            foreach(var item in categorys) {
                Console.WriteLine(item);
            }
        }


        private static void Exercise1_6() {
            //var categorys = Library.Categories.OrderBy(c=> c.Name).ToList();
            //var books = Library.Books;
            //foreach(var category in categorys) {
            //    Console.WriteLine("#{0}", category.Name);
            //    foreach(var book in books) {
            //       Console.WriteLine("　{0}",book.Title);
            //    }
            //}

            var groups = Library.Books.GroupBy(b => b.CategoryId);
            var categorys = Library.Categories.OrderBy(c => c.Name);
            foreach(var category in categorys) {
                Console.WriteLine("#{0}", category.Name);
                foreach(var book in groups) {
                    foreach(var b in book) {
                        if(b.CategoryId == category.Id) {
                            Console.WriteLine("　{0}", b.Title);
                        }
                    }
                }
            }

        }


        private static void Exercise1_7() {
        }


        private static void Exercise1_8() {
        }
    }
}
