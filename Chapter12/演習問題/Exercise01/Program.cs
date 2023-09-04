﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            //Console.WriteLine(File.ReadAllText("employees.json"));
        }


        private static void Exercise1_1(string v) {
            var employee = new Employee {
                Id = 12345,
                Name = "Sam",
                HireDate = DateTime.Today,
            };

            //シリアル化
            using(var writer = XmlWriter.Create(v)) {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer,employee);
            }

            //逆シリアル化
            using(var reader = XmlReader.Create(v)) {
                var serializer = new XmlSerializer(typeof(Employee));
                employee = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(employee);
            }
        }


        private static void Exercise1_2(string v) {
            var employees = new Employee[] {
                new Employee {
                    Id = 12345,
                    Name = "Sam",
                    HireDate = DateTime.Today,
                },
                new Employee {
                    Id = 67890,
                    Name = "Tom",
                    HireDate = DateTime.Today,
                }
            };

            using(var writer = XmlWriter.Create(v)) {
                var serializer = new DataContractSerializer(employees.GetType());
                serializer.WriteObject(writer, employees);
            }
        }

        private static void Exercise1_3(string v) {


        }

        private static void Exercise1_4(string v) {


        }
    }
}
