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


        //画像の追加
        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }


        //dgvの削除
        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentRow.Index);
        }


        //dgvの変更
        private void btModifiReport_Click(object sender, EventArgs e) {
            foreach(DataGridViewRow row in dgvCarReports.SelectedRows) {
                int iRow = dgvCarReports.CurrentCell.RowIndex;
            }

        }


        //
        private void dgvCarReports_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
            getSelectMaker3();
            cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
            //pbCarImage.Image = (PictureBox)dgvCarReports.CurrentRow.Cells[5].Value;

        }


        private CarReport.MakerGroup getSelectMaker3() {
            if(dgvCarReports.CurrentRow.Cells[2].Value.ToString() == "トヨタ") {
                return CarReport.MakerGroup.トヨタ;
            } else if(dgvCarReports.CurrentRow.Cells[2].Value.ToString() == "日産") {
                return CarReport.MakerGroup.日産;
            } else if(dgvCarReports.CurrentRow.Cells[2].Value.ToString() == "ホンダ") {
                return CarReport.MakerGroup.ホンダ;
            } else if(dgvCarReports.CurrentRow.Cells[2].Value.ToString() == "スバル") {
                return CarReport.MakerGroup.スバル;
            } else if(dgvCarReports.CurrentRow.Cells[2].Value.ToString() == "スズキ") {
                return CarReport.MakerGroup.スズキ;
            } else if(dgvCarReports.CurrentRow.Cells[2].Value.ToString() == "ダイハツ") {
                return CarReport.MakerGroup.ダイハツ;
            } else if(dgvCarReports.CurrentRow.Cells[2].Value.ToString() == "輸入車") {
                return CarReport.MakerGroup.輸入車;
            } else {
                return CarReport.MakerGroup.その他;
            }
        }

    }
}
