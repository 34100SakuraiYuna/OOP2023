using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp2 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            var str = "("+dayOfWeek+")　";
            tbTimeNow.Text = DateTime.Now.ToString("yyyy/MM/dd") + str + DateTime.Now.ToString("HH:mm:ss");
        }

        private void btDayCalc_Click(object sender, EventArgs e) {
            var now = DateTime.Now;
            var dtp = dtpDate.Value;
            var distance = now - dtp;

            //模範解答
            tbMessage.Text = "入力した日付から"+(now-dtp).Days+"日経過";
            //自分が書いたやつ
            //tbMessage.Text = distance.Days.ToString();
            
        }

        private void btAge_Click(object sender, EventArgs e) {
            var now = DateTime.Now;
            var birthday = dtpDate.Value;
            var age = now.Year - birthday.Year;
            if(now < birthday.AddYears(age)) {
                age--;
            }

            //模範解答
            //var age = GetAge(dtpDate.Value, DateTime.Now);
            tbMessage.Text = "あなたの年齢は"+ age + "歳です";

        }

        public static int GetAge(DateTime birthday,DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if(targetDay < birthday.AddYears(age)) {
                age--;
            }

            return age;
        }
    }
}
