using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Bar : Obj {
        



        public Bar(double xp,double yp) : base(xp,yp, @"pic\bar.png") {
            MoveX = 10;
            MoveY = 0;            
        }

       


        public override void Move() {
            ;
        }

        public override void Move(Keys direction) {
            //PosX += 20;

            if (direction == Keys.Right)
            {
                if (PosX < 584)
                {
                    PosX += 2;
                }
            }
            else if (direction == Keys.Left)
            {
                if (PosX > 2)
                {
                    PosX -= 2;
                }
            }
        }
    }
}
