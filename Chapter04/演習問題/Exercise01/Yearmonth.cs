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
               return (2001 <= Year && Year <= 2100);
            }
        }

        public Yearmonth addOneMonth() {
            Yearmonth yearMonth = new Yearmonth(2020,12);
                
            if(yearMonth.Month == 12) {
                yearMonth.Month = 1;
                yearMonth.Year++;
            } else { 
                yearMonth.Month++;
            }
            return yearMonth;
        }


        //public override string ToString() {
        //    return "{0}年{1}月",Year,Month;
        //}
    }
}
