using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class dgvCarReport : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();


        public dgvCarReport() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports;
        }


        private void Form1_Load(object sender, EventArgs e) {

        }


        //追加ボタンがクリックされた時のイベントハンドラ
        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
                Maker = getSelectMaker(),
            };
            //dgvCarReports.
        }


        private CarReport.MakerGroup getSelectMaker() {
            if(rbToyota.Checked == true) {
                return CarReport.MakerGroup.トヨタ;
            } else if(rbNissan.Checked == true) {
                return CarReport.MakerGroup.日産;
            } else if(rbHonda.Checked == true) {
                return CarReport.MakerGroup.ホンダ;
            } else if(rbSubaru.Checked == true) {
                return CarReport.MakerGroup.スバル;
            } else if(rbSuzuki.Checked == true) {
                return CarReport.MakerGroup.スズキ;
            } else if(rbDaihatsu.Checked == true) {
                return CarReport.MakerGroup.ダイハツ;
            } else if(rbImported.Checked == true) {
                return CarReport.MakerGroup.輸入車;
            } else if(rbOther.Checked == true) {
                return CarReport.MakerGroup.その他;
            } else {
                return default;
            }
        }
    }
}
