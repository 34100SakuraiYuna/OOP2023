﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(IsPhoneNumber("090-9111-1234"));
            Console.WriteLine(IsPhoneNumber("080-9111-1234"));
            Console.WriteLine(IsPhoneNumber("090-9111-1234"));
            Console.WriteLine(IsPhoneNumber("060-9111-1234"));
            Console.WriteLine(IsPhoneNumber("190-9111-1234"));
            Console.WriteLine(IsPhoneNumber("091-9111-1234"));
            Console.WriteLine(IsPhoneNumber("090-9111-12341"));
            Console.WriteLine(IsPhoneNumber("A090-9111-1234"));
            Console.WriteLine(IsPhoneNumber("090-911-1234"));
            Console.WriteLine(IsPhoneNumber("090-1911-234"));
        }


        private static bool IsPhoneNumber(string str) {
            bool isMatch = Regex.IsMatch(str, @"^(0[7-9]0)-\d{4}-\d{4}$");
            if(isMatch) {
                return true;
            } else {
                return false;
            }
        }
    }
}
