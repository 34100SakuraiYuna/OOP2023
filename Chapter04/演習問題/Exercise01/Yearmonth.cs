using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class Yearmonth {
        public Yearmonth(int year, int month) {
            Year = year;
            Month = month;
        }

        public int Year { get; private set; }
        public int Month { get; private set; }




        public bool Is12Century {
            get {
               return (2001 <= this.Year && this.Year <= 2100);
            }
        }

        //public YearMonth addOneMonth() { 

        //}


        //public override string ToString() { 

        //}
    }
}
