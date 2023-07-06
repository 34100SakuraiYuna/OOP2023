using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp2 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDayCalc_Click(object sender, EventArgs e) {
            var now = DateTime.Now;
            var dtp = dtpDate.Value;
            var distance = now - dtp;


            //tbMessage.Text = "入力した日付から"+(now-dtp).Day+"日経過";
            tbMessage.Text = distance.Days.ToString();
            tbTimeNow.Text = now.ToString("HH:mm");
        }
    }
}
