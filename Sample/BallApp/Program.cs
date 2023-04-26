using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program : Form {
        private Timer moveTimer;    //タイマー用
        private PictureBox pb;
        private List<Obj> balls = new List<Obj>();    //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>();      //表示用

        Bar bar;            //Barのインスタンス格納用
        PictureBox pbBar;   //画像を表示するコントロール


        static void Main(string[] args) {
            Application.Run(new Program());
        }


        public Program() {
            this.Size = new Size(800, 600);
            this.BackColor = Color.Green;

            this.MouseClick += Program_MouseClick;
            this.KeyDown += Program_KeyDown;

            bar = new Bar(300,500);
            pbBar = new PictureBox();
            pbBar.Image = bar.Image;
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY); //画像の位置
            pbBar.Size = new Size(200, 15);
            pbBar.SizeMode = PictureBoxSizeMode.StretchImage;  //画像の表示モード
            pbBar.Parent = this;

            moveTimer = new Timer();
            moveTimer.Interval = 10; //タイマーのインターバル（ms）
            moveTimer.Tick += MoveTimer_Tick;  //デリゲート登録
        }


        //キーが押された時のイベントハンドラ
        private void Program_KeyDown(object sender, KeyEventArgs e) {
            bar.Move(e.KeyData);
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);
        }


        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {
            Obj ballObj = null;
            pb = new PictureBox();   //画像を表示するコントロール
            
            //ボールインスタンス生成
            if (e.Button == MouseButtons.Left){
                ballObj = new SoccerBall(e.X - 25, e.Y - 25);
                pb.Size = new Size(50, 50); //画像の表示サイズ
            }else if(e.Button == MouseButtons.Right){
                ballObj = new TennisBall(e.X - 12, e.Y - 12);
                pb.Size = new Size(25, 25); //画像の表示サイズ
            }

            pb.Image = ballObj.Image;
            pb.Location = new Point((int)ballObj.PosX, (int)ballObj.PosY);　//画像の位置
            pb.SizeMode = PictureBoxSizeMode.StretchImage;  //画像の表示モード
            pb.Parent = this;

            balls.Add(ballObj);
            pbs.Add(pb);

            this.Text = "BallGamr   soccer:" + SoccerBall.Count + "   tennis:" + TennisBall.Count;

            moveTimer.Start();  //タイマースタート
        }


        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(object sender, EventArgs e) {
            for (int i = 0; i < balls.Count; i++){
                balls[i].Move(pbBar,pbs[i]);  //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY); //画像の位置
            }
        }
    }
}
