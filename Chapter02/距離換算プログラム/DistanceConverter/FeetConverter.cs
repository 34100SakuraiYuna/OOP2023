using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    //フィートとメートルの単位変換クラス
    public static class FeetConverter {
        private const double RATIO = 0.3048;    //定数
        //public static readonly double ratio = 0.3048;

        //メートルからフィートを求める
        public static double FromMeter(double meter) {
            return meter / RATIO;
        }
        

        //フィートからメートルを求める
        public static double ToMeter(double feet) {
            return feet * RATIO;
        }
    }
}
