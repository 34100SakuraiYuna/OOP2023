﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework.Models {
    internal class Configuration : DbMigrationsConfiguration<BooksDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;  //自動マイグレーションの有効化
            AutomaticMigrationDataLossAllowed = true;   //データロスを伴う更新の有効化
            ContextKey = "SampleEntityFramework.Models.BooksDbContext";
        }
    }
}