﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class Bar : Obj {
        



        public Bar(double xp,double yp) : base(xp,yp, @"pic\bar.png") {
            
        }




        public override void Move() {
            /*  if (PosY > 520 || PosY < 0){
                  MoveY = -MoveY;
              }

              if (PosX > 730 || PosX < 0){
                  MoveX = -MoveX;
              }
              PosX += MoveX;
              PosY += MoveY;*/
        }
    }
}
