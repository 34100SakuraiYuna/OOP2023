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
            //dgvの画像を非表示
            dgvCarReports.Columns[5].Visible = false;

            buttonMask();
            statusLabelDisp();
        }



        //dgvの追加ボタン
        private void btAddReport_Click(object sender, EventArgs e) {
            statusLabelDisp();

            if(cbAuthor.Text == "" && cbCarName.Text == "") {
                statusLabelDisp("記録者と車名を入力してください");
                return;
            } else if(cbCarName.Text == "") {
                statusLabelDisp("車名を入力してください");
                return;
            } else if(cbAuthor.Text == "") {
                statusLabelDisp("記録者を入力してください");
                return;
            }

            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
                Maker = getSelectMaker(),
            };
            CarReports.Add(carReport);

            //コンボボックスの履歴追加
            addComboBox();
            clearCommand();
            buttonMask();
        }


        //コンボボックスの履歴追加
        private void addComboBox() {
            if(!cbAuthor.Items.Contains(cbAuthor.Text)) {
                cbAuthor.Items.Add(cbAuthor.Text);
            }

            if(!cbCarName.Items.Contains(cbCarName.Text)) {
                cbCarName.Items.Add(cbCarName.Text);
            }
        }


        private void removeComboBox() {

        }



        //選択されているメーカーを返却
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


        //別解 選択されているメーカーを返却
        private CarReport.MakerGroup getSelectMaker2() {
            foreach(var item in gbMaker.Controls) {
                if(((RadioButton)item).Checked) {
                    return (CarReport.MakerGroup)int.Parse(((RadioButton)item).Tag.ToString());
                }
            }
            return CarReport.MakerGroup.その他;

        }


        //画像の追加ボタン
        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
            
        }


        //dgvの削除ボタン
        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentRow.Index);
            buttonMask();
            clearCommand();
        }


        //dgvの修正ボタン
        private void btModifiReport_Click(object sender, EventArgs e) {
            if(cbAuthor.Text == "" && cbCarName.Text == "") {
                statusLabelDisp("記録者と車名を入力してください");
                return;
            } else if(cbCarName.Text == "") {
                statusLabelDisp("車名を入力してください");
                return;
            } else if(cbAuthor.Text == "") {
                statusLabelDisp("記録者を入力してください");
                return;
            }
            CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
            CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
            CarReports[dgvCarReports.CurrentRow.Index].Maker = getSelectMaker();
            CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
            CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
            CarReports[dgvCarReports.CurrentRow.Index].CarImage = pbCarImage.Image;
            cbAuthor.Items.Remove("");
            addComboBox();
            dgvCarReports.Refresh();    //一覧更新
        }


        //レコードの選択
        private void dgvCarReports_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
            selectedMaker((CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value);
            cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
            pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;
            buttonMask();
        }


        //指定したメーカーのラジオボタンをセット
        private void selectedMaker(CarReport.MakerGroup makerGroup) {
            switch(makerGroup) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.スズキ:
                    rbSuzuki.Checked = true;
                    break;
                case CarReport.MakerGroup.ダイハツ:
                    rbDaihatsu.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImported.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
                default:
                    break;
            }
        }


        //入力内容のリセット
        public void clearCommand() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = null;
            cbCarName.Text = null;
            tbReport.Text = null;
            pbCarImage.Image = null;
            rbToyota.Checked = true;

            dgvCarReports.ClearSelection();
            buttonMask();
        }


        //終了
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }


        //ステータスラベルのテキスト表示
        private void statusLabelDisp(string msg = "") {
            tsInfoText.Text = msg;
        }


        //画像の削除ボタン
        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }


        //マスク処理
        private void buttonMask() {
            btModifiReport.Enabled = true;
            btDeleteReport.Enabled = true;

            if(dgvCarReports.RowCount < 1 || cbAuthor.Text == "") {
                btModifiReport.Enabled = false;
                btDeleteReport.Enabled = false;
            }
        }


        //バージョン情報の表示
        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();    //モーダルダイアログとして表示
        }


        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {

        }
    }
}
