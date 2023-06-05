using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            //{\rtf1}
        }

        private static void Exercise3_1(string text) {
            int count = text.Count(c => c == ' ');
            
            
            Console.WriteLine("空白数：{0}",count);
        }

        private static void Exercise3_2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3_3(string text) {
            string[] words = text.Split(' ').ToArray();


            Console.WriteLine("単語数：" + words.Length);
        }

        private static void Exercise3_4(string text) {
            string[] words = text.Split(' ').ToArray();

            foreach(var i in words) {
                if(i.Length <= 4) {
                    Console.WriteLine(i);
                }
            }
        }

        private static void Exercise3_5(string text) {
            string[] texts = text.Split(' ').ToArray();
            var sb = new StringBuilder();
            foreach(var word in texts) {
                sb.Append(word);
                sb.Append(' ');
            }

            text = sb.ToString();
            Console.WriteLine(text);
        }
    }
}
