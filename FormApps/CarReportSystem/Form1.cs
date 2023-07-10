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
            dgvCarReports.Columns[5].Visible = false;
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
            CarReports.Add(carReport);
        }


        private CarReport.MakerGroup getSelectMaker() {
            if(rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
            } else if(rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
            } else if(rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
            } else if(rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            } else if(rbSuzuki.Checked) {
                return CarReport.MakerGroup.スズキ;
            } else if(rbDaihatsu.Checked) {
                return CarReport.MakerGroup.ダイハツ;
            } else if(rbImported.Checked) {
                return CarReport.MakerGroup.輸入車;
            } else {
                return CarReport.MakerGroup.その他;
            }
        }


        //別解
        private CarReport.MakerGroup getSelectMaker2() {
            foreach(var item in gbMaker.Controls) {
                if(((RadioButton)item).Checked) {
                    return (CarReport.MakerGroup)int.Parse(((RadioButton)item).Tag.ToString());
                }
            }
            return CarReport.MakerGroup.その他;

        }


        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }


        private void btDeleteReport_Click(object sender, EventArgs e) {
            foreach(DataGridViewRow row in dgvCarReports.SelectedRows) {
                dgvCarReports.Rows.RemoveAt(row.Index);
            }
        }
    }
}
