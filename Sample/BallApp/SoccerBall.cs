using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class SoccerBall : Obj{
        //フィールド        
        private static int count;//インスタンスの個数
        Random random = new Random();   //乱数インスタンス


        //プロパティ
        public static int Count { get => count; set => count = value;}


        //コンストラクタ
        public SoccerBall( double xp, double yp ) 
            : base(xp,yp, @"pic\soccer_ball.png"){
            int rndX = random.Next(-25, 25);
            MoveX = (rndX != 0 ? rndX : 1); //乱数で移動量を設定

            int rndY = random.Next(-25, 25);
            MoveY = (rndY != 0 ? rndY : 1); //乱数で移動量を設定

            Count++;
        }       
        
        
        //メソッド
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

        public override void Move(Keys direction) {
            ;
        }
    }
}
