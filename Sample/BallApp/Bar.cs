using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class Bar : Obj {
        Random random = new Random();   //乱数インスタンス



        public Bar(double x,double y) : base(x,y,@"pic_bar.png"){
            int rndX = random.Next(-25, 25);
            MoveX = (rndX != 0 ? rndX : 1); //乱数で移動量を設定

            int rndY = random.Next(-25, 25);
            MoveY = (rndY != 0 ? rndY : 1); //乱数で移動量を設定

        }




        public override void Move() {
            if (PosY > 520 || PosY < 0){
                MoveY = -MoveY;
            }

            if (PosX > 730 || PosX < 0){
                MoveX = -MoveX;
            }

            PosX += MoveX;
            PosY += MoveY;
        }
    }
}
