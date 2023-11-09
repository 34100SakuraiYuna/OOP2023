using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    public class PoundUnit : DistanceUnit {
        //グラム単位を表すクラス
        private static List<PoundUnit> units = new List<PoundUnit> {
           new PoundUnit{ Name = "oz",Coefficient=1,},
           new PoundUnit{ Name = "lb",Coefficient=1*16},
       };


        public static ICollection<PoundUnit> Units { get { return units; } }


        /// <summary>
        /// グラム単位からポンド単位に変換する
        /// </summary>
        /// <param name="unit">ポンド単位</param>
        /// <param name="value">値</param>
        /// <returns>ポンド単位</returns>
        public double FromGrammeUnit(GrammeUnit unit, double value) {
            return (value * unit.Coefficient) * 0.0022046 / this.Coefficient;
        }
    }
}

