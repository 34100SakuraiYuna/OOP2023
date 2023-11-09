using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    public class GrammeUnit : DistanceUnit{
        //グラム単位を表すクラス
       private static List<GrammeUnit> units = new List<GrammeUnit> {
           new GrammeUnit{ Name = "g",Coefficient=1,},
           new GrammeUnit{ Name = "kg",Coefficient=1*1000},
       };


       public static ICollection<GrammeUnit> Units { get { return units; } }


            /// <summary>
            /// ポンド単位からグラム単位に変換する
            /// </summary>
            /// <param name="unit">ポンド単位</param>
            /// <param name="value">値</param>
            /// <returns>グラム単位</returns>
        public double FromPoundUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) * 453.6 / this.Coefficient;
        }
     }
}
