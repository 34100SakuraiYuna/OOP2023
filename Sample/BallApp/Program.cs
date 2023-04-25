﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program : Form {

        private Timer moveTimer;    //タイマー用
        private SoccerBall soccerBall;
        private TennisBall tennisBall;
        private PictureBox pb;



        private List<Obj> balls = new List<Obj>();    //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>();      //表示用
        


        private int count = 0;

        static void Main(string[] args) {
            Application.Run(new Program());
        }

        public Program() {
            this.Size = new Size(800, 600);
            this.BackColor = Color.Green;
            this.MouseClick += Program_MouseClick;
      

            

            moveTimer = new Timer();
            moveTimer.Interval = 10; //タイマーのインターバル（ms）
            moveTimer.Tick += MoveTimer_Tick;  //デリゲート登録
        }

       

       
        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {

            

            if (e.Button == MouseButtons.Left){
                //ボールインスタンス生成
                soccerBall = new SoccerBall(e.X - 25, e.Y - 25);
                pb = new PictureBox();   //画像を表示するコントロール
                pb.Image = soccerBall.Image;
                pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY);　//画像の位置
                pb.Size = new Size(50, 50); //画像の表示サイズ
                pb.SizeMode = PictureBoxSizeMode.StretchImage;  //画像の表示モード
                pb.Parent = this;

                //count += 1;
                //this.Text = count + "個";
                //this.Text = "BallGame:"  +bolls.Count;

                balls.Add(soccerBall);  
                pbs.Add(pb);
            }else{
                tennisBall = new TennisBall(e.X - 25, e.Y - 25);
                pb = new PictureBox();
                pb.Image = tennisBall.Image;
                pb.Location = new Point((int)tennisBall.PosX, (int)tennisBall.PosY);　//画像の位置
                pb.Size = new Size(25, 25); //画像の表示サイズ
                pb.SizeMode = PictureBoxSizeMode.StretchImage;  //画像の表示モード
                pb.Parent = this;
                balls.Add(soccerBall);
                pbs.Add(pb);
            }
            

            this.Text = "BallGamr:" + SoccerBall.Count + ":" + TennisBall.Count;

            moveTimer.Start();  //タイマースタート
        }

        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(object sender, EventArgs e) {

            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Move();  //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY); //画像の位置
            }
        }
    }
}