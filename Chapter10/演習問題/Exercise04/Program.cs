using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var count = -1;
            var lines = File.ReadAllLines("sample.txt");
            foreach(var item in lines) {
                count ++;
                lines[count] = Regex.Replace(item,@".*(=).*","=");
                lines[count] = Regex.Replace(item, "v4.0", "v5.0");
            }

            File.WriteAllLines("sample.txt",lines);

            // これ以降は確認用
            var text = File.ReadAllText("sample.txt");
            Console.WriteLine(text);
        }
    }
}
