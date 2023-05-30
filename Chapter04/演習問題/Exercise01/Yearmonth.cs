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
            if(Month == 12) {
                return new Yearmonth(Year + 1, Month = 1);
            } else {
                return new Yearmonth(Year, Month + 1);
            }
            //1行で書いたバージョン
            //return new Yearmonth(Month == 12 ? Year + 1 : Year, Month == 12 ? 1 : Month + 1);
        }


        public override string ToString() {
            return Year + "年" + Month + "月";
        }
    }
}
