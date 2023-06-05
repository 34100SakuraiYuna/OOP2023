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
            //string[] words = text.Split(' ').ToArray();
            //Console.WriteLine("単語数：" + words.Length);

            //模範解答
            var count = text.Split(' ').Length;
            Console.WriteLine("単語数：{0}",count);

        }

        private static void Exercise3_4(string text) {
            //string[] words = text.Split(' ').ToArray();

            //foreach(var i in words) {
            //    if(i.Length <= 4) {
            //        Console.WriteLine(i);
            //    }
            //}


            //模範解答
            var words = text.Split(' ').Where(word => word.Length <= 4);
            foreach(var word in words) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            //string[] texts = text.Split(' ').ToArray();
            //var sb = new StringBuilder();
            //foreach(var word in texts) {
            //    sb.Append(word);
            //    sb.Append(' ');
            //}

            //text = sb.ToString();
            //Console.WriteLine(text);


            //模範解答
            var array = text.Split(' ').ToArray();
            var sb = new StringBuilder(array[0]);

            if(array.Length > 0) {
                //Skipは()内の要素を飛ばせる
                foreach(var word in array.Skip(1)) {
                    sb.Append(' ');
                    sb.Append(word);
                }
            }
            var createWords = sb.ToString();
            Console.WriteLine(createWords);
        }
    }
}
