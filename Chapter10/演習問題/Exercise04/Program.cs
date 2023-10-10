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
            var lines = File.ReadAllLines("sample.txt");

            #region　自分の回答
            //var count = -1;

            //foreach(var item in lines) {
            //    count ++;
            //    lines[count] = Regex.Replace(item,@".*(=).*","=");
            //    lines[count] = Regex.Replace(item, "v4.0", "v5.0");
            //}
            //File.WriteAllLines("sample.txt", lines);
            #endregion

            //模範解答
            var newLines = lines.Select(s=> Regex.Replace(s,@"\b(V|v)ersion\s*=\s*""v4.0""",@"version=""5.0"""));
            File.WriteAllLines("sample.txt",newLines);
            
            // これ以降は確認用
            var text = File.ReadAllText("sample.txt");
            Console.WriteLine(text);
        }
    }
}
