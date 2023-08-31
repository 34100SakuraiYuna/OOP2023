using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class dgvCarReport : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();
        private uint mode;


        //設定情報保存用オブジェクト
        Settings settings = new Settings();


        public dgvCarReport() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports;
        }


        private void Form1_Load(object sender, EventArgs e) {
            //dgvの画像を非表示
            dgvCarReports.Columns[5].Visible = false;
            
            buttonMask();
            statusLabelDisp("");
            nowTime();
            tmTimeUpdate.Start();

            dgvCarReports.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;

            try {
                //設定ファイルを逆シリアル化して背景設定
                using(var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
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
            addComboBox(cbAuthor.Text, cbCarName.Text);
            clearCommand();
            buttonMask();
        }


        //コンボボックスの履歴追加
        private void addComboBox(string author,string carName) {
            if(!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }

            if(!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }


        //コンボボックスの履歴全削除
        private void allClearComboBox() {
            cbAuthor.Items.Clear();
            cbCarName.Items.Clear();

        }
        
        
        //コンボボックスの履歴削除(1つ)
        private void oneRemoveComboBox(string author,string carName) {
            cbAuthor.Items.Remove(author);
            cbCarName.Items.Remove(carName);

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
            if(ofdImageFileOpen.ShowDialog() == DialogResult.OK) {
                pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
            }
            buttonMask();
        }


        //dgvの削除ボタン
        private void btDeleteReport_Click(object sender, EventArgs e) {
            //oneRemoveComboBox(dgvCarReports.CurrentRow.ToString(), dgvCarReports.CurrentRow.ToString());
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
            addComboBox(cbAuthor.Text, cbCarName.Text);
            dgvCarReports.Refresh();    //一覧更新
        }


        //レコードの選択(古い方)
        private void dgvCarReports_Click(object sender, EventArgs e) {
            //if(dgvCarReports.RowCount > 0) {
            //    dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
            //    cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
            //    selectedMaker((CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value);
            //    cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
            //    tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
            //    pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;
            //    buttonMask();
            //}
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


        //画像の削除ボタン
        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
            buttonMask();
        }


        //マスク処理
        private void buttonMask() {
            btModifiReport.Enabled = true;
            btDeleteReport.Enabled = true;
            btScaleChange.Enabled = true;

            if(dgvCarReports.RowCount < 1 || cbAuthor.Text == "") {
                btModifiReport.Enabled = false;
                btDeleteReport.Enabled = false;
            }

            if(pbCarImage.Image == null) {
                btScaleChange.Enabled = false;
            }
        }


        //バージョン情報の表示
        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();    //モーダルダイアログとして表示
        }


        //編集の色設定
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if(cdColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }
        }


        //サイズ変更button
        private void btScaleChange_Click(object sender, EventArgs e) {
            mode++;
            if(mode == 1) {
                mode = 3;
            }else if(mode > 4) {
                mode = 0;
            }
            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;

            ////別解
            //mode = mode < 4 ? ((mode == 1) ? 3 : ++mode) : 0;
            //pbCarImage.SizeMode = (PictureBoxSizeMode)mode;
        }


        //設定ファイルのシリアル化
        private void dgvCarReport_FormClosed(object sender, FormClosedEventArgs e) {
            using(var writer = XmlWriter.Create("Settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer,settings);
            }
        }


        //ステータスラベルのテキスト表示
        private void statusLabelDisp(string msg = "") {
            tsInfoText.Text = msg;
            tsInfoText.BackColor = Color.White;
            tsInfoText.ForeColor = Color.Red;
        }


        //現在時刻の表示
        private void nowTime() {
            var now = DateTime.Now;
            tsTimeDisp.Text = now.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            tsTimeDisp.BackColor = Color.White;
            tsTimeDisp.ForeColor = Color.Black;
        }


        //1秒ごとに行うやつ
        private void tmTimeUpdate_Tick(object sender, EventArgs e) {
            nowTime();
        }


        //保存ボタン
        private void 保存LToolStripMenuItem_Click(object sender, EventArgs e) {
            if(sfdCarRepoSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();
                    using(FileStream fs = File.Open(sfdCarRepoSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, CarReports);
                    }
                } catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //開くボタン
        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e) {
            if(ofdCarRepoOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
                    var bf = new BinaryFormatter();
                    using(FileStream fs = File.Open(ofdCarRepoOpen.FileName, FileMode.Open,FileAccess.Read)) {
                        CarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReports.DataSource = null;
                        dgvCarReports.DataSource = CarReports;

                        clearCommand();
                        allClearComboBox();
                        dgvCarReports.Columns[5].Visible = false;

                        foreach(var carReport in CarReports) {
                            addComboBox(carReport.Author,carReport.CarName);
                        }
                    }
                } catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }


        }


        //レコードの選択
        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
            if(dgvCarReports.RowCount > 0) {
                dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
                selectedMaker((CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value);
                cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
                tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
                pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;
                buttonMask();
            }
        }
    }
}