﻿using System;
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
                Console.WriteLine("　{0}冊", count);
            }

            //模範解答
            //var query = Library.Books.GroupBy(b => b.PublishedYear)
            //    .Select(g => new { PublishedYear = g.Key, Count = g.Count() })
            //    .OrderBy(x => x.PublishedYear);
            //foreach(var item in query) {
            //    Console.WriteLine("{0}年　{1}冊", item.PublishedYear, item.Count);
            //}
        }


        private static void Exercise1_4() {
            var groups = Library.Books.OrderByDescending(b => b.PublishedYear).OrderByDescending(b => b.Price);
            var categorys = Library.Categories.ToList();
            foreach(var g in groups) {
                Console.WriteLine("{0}年　{1}円　{2}　({3})"
                    , g.PublishedYear, g.Price, g.Title, categorys[(g.CategoryId) - 1].Name);
            }

            //模範解答
            //var query = Library.Books.Join(Library.Categories,
            //    book=> book.CategoryId,
            //    category=> category.Id,
            //    (book,category)=> new {
            //            PublishedYear = book.PublishedYear,
            //            Price = book.Price,
            //            Title = book.Title,
            //            CategoryName = category.Name,
            //        }
            //    ).OrderByDescending(x=> x.PublishedYear)
            //    .ThenByDescending(x=> x.Price);

            //foreach(var item in query) {
            //    Console.WriteLine("{0}年　{1}円　{2}　({3})"
            //        ,item.PublishedYear,item.Price,item.Title,item.CategoryName);
            //}

        }


        private static void Exercise1_5() {
            var lookup = Library.Books.ToLookup(b => b.PublishedYear);
            var books = lookup[2016];
            var categorys = Library.Categories.Select(c => c.Name);

            foreach(var item in categorys) {
                Console.WriteLine(item);
            }

            //模範解答
            //var query = Library.Books.Where(b=> b.PublishedYear == 2016)
            //    .Join(Library.Categories,
            //    book => book.CategoryId,
            //    category => category.Id,
            //    (book, category) => category.Name).Distinct();

            //foreach(var name in query) {
            //    Console.WriteLine(name);
            //}
        }


        private static void Exercise1_6() {
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

            //模範解答
            //var query = Library.Books
            //    .Join(Library.Categories,
            //    book => book.CategoryId,
            //    category => category.Id,
            //    (book, category) => new { 
            //        book.PublishedYear,
            //        book.Price,
            //        book.Title,
            //        CategoryName = category.Id
            //    })
            //    .GroupBy(x=> x.CategoryName)
            //    .OrderBy(x=> x.Key);

            //foreach(var group in query) {
            //    Console.WriteLine("#{0}", group.Key);
            //    foreach(var item in group) {
            //        Console.WriteLine("　{0}", item.Title);
            //    }
            //}
        }


        private static void Exercise1_7() {
            //var a = Library.Books.GroupBy(g=> g.PublishedYear);
            //var groups = Library.Categories
            //    .Join(a,
            //    c => c.Id,
            //    b => b.Key,
            //    (c, books) => new {
            //        Category = c.Name,
            //        Books = books
            //    });

            //foreach(var group in a) {
            //    foreach(var i in group) {

            //    }
            //}

            //模範解答
            var catid = Library.Categories.Single(c => c.Name == "Development").Id;
            var groups = Library.Books.Where(b => b.CategoryId == catid)
                                      .GroupBy(b => b.PublishedYear)
                                      .OrderBy(b => b.Key);
            foreach(var group in groups) {
                Console.WriteLine("#{0}年",group.Key);
                foreach(var book in group) {
                    Console.WriteLine("　{0}",book.Title);
                }
            }
        }


        private static void Exercise1_8() {
            var groups = Library.Categories.GroupJoin(Library.Books,
                c => c.Id,
                b => b.CategoryId,
                (c, books) => new {
                    Category = c.Name,
                    Books = books
                });

            foreach(var group in groups) {
                if(group.Books.Count() >= 4) {
                    Console.WriteLine(group.Category);
                }
            }

            //模範解答
            //var query = Library.Categories
            //                   .GroupJoin(Library.Books,
            //                              c => c.Id,
            //                              b => b.CategoryId,
            //                              (c, b) => new {
            //                                  CategoryName = c.Name,
            //                                  Count = b.Count()
            //                              })
            //                   .Where(x => x.Count >= 4);
            //foreach(var category in query) {
            //    Console.WriteLine(category.CategoryName);
            //}
        }
    }
}
