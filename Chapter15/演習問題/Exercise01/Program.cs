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
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }


        private static void Exercise1_2() {
            var maxPrice = Library.Books.Max(b=> b.Price);
            var book = Library.Books
                  .First(b => b.Price == maxPrice);
            Console.WriteLine(book);
        }


        private static void Exercise1_3() {
            var count = 0;
            var groups = Library.Books.GroupBy(b => b.PublishedYear).OrderBy(g => g.Key);
            foreach(var g in groups) {
                Console.WriteLine($"{g.Key}年");
                foreach(var book in g) {
                    count++;
                }
                Console.WriteLine("{0}冊",count);
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
        }


        private static void Exercise1_6() {
        }


        private static void Exercise1_7() {
        }


        private static void Exercise1_8() {
        }
    }
}
