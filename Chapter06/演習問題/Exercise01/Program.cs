using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);

        }

        private static void Exercise1_1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }


        private static void Exercise1_2(int[] numbers) {
            var num = numbers.Skip(numbers.Length-2);
            foreach(var i in num) {
                Console.WriteLine(i);
            }
        }


        private static void Exercise1_3(int[] numbers) {
            string[] strs = new string[numbers.Length];
            for(int i = 0; i < numbers.Length; i++) {
                strs[i] = numbers.ToString(); ;
            }
        }


        private static void Exercise1_4(int[] numbers) {
            var sortNumber = numbers.OrderBy(i=> i).Take(3);
            
            foreach(var i in sortNumber) {
                Console.WriteLine(i);
            }
        }

        private static void Exercise1_5(int[] numbers) {
            var results = numbers.Distinct().Count(i => i > 10);
            Console.WriteLine(results);
        }
    }
}
