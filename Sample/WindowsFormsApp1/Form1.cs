﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton_Click(object sender, EventArgs e) {
            //tbAns.Text =(int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text)).ToString();

            int num1 = int.Parse(tbNum1.Text);
            int num2 = int.Parse(tbNum2.Text);
            int sum = num1 + num2;
            tbAns.Text = sum.ToString();
        }

        //イベントハンドラ
        private void btPow_Click(object sender, EventArgs e) {
/*
            int ans = (int)nudX.Value;
            for (int i = 0; i < nudY.Value-1; i++) { 
                ans *= (int)nudX.Value;
            }
            tbResult.Text = ans.ToString();
*/
            double result = Math.Pow((double)nudX.Value, (double)nudY.Value);
            tbResult.Text = result.ToString();
        }
    }
}
