
namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb8 = new System.Windows.Forms.RadioButton();
            this.rb7 = new System.Windows.Forms.RadioButton();
            this.rb6 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbUrl.Location = new System.Drawing.Point(30, 44);
            this.tbUrl.Multiline = true;
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(592, 51);
            this.tbUrl.TabIndex = 0;
            // 
            // btGet
            // 
            this.btGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btGet.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btGet.Location = new System.Drawing.Point(628, 44);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(145, 51);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = false;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(247, 101);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(526, 220);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.SelectedIndexChanged += new System.EventHandler(this.lbRssTitle_SelectedIndexChanged);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbBrowser.Location = new System.Drawing.Point(30, 339);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.Size = new System.Drawing.Size(743, 320);
            this.wbBrowser.TabIndex = 3;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(17, 28);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(47, 16);
            this.rb1.TabIndex = 4;
            this.rb1.TabStop = true;
            this.rb1.Text = "主要";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rb8);
            this.groupBox1.Controls.Add(this.rb7);
            this.groupBox1.Controls.Add(this.rb6);
            this.groupBox1.Controls.Add(this.rb5);
            this.groupBox1.Controls.Add(this.rb4);
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(30, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 220);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rb8
            // 
            this.rb8.AutoSize = true;
            this.rb8.Location = new System.Drawing.Point(17, 189);
            this.rb8.Name = "rb8";
            this.rb8.Size = new System.Drawing.Size(47, 16);
            this.rb8.TabIndex = 11;
            this.rb8.TabStop = true;
            this.rb8.Text = "科学";
            this.rb8.UseVisualStyleBackColor = true;
            // 
            // rb7
            // 
            this.rb7.AutoSize = true;
            this.rb7.Location = new System.Drawing.Point(17, 166);
            this.rb7.Name = "rb7";
            this.rb7.Size = new System.Drawing.Size(33, 16);
            this.rb7.TabIndex = 10;
            this.rb7.TabStop = true;
            this.rb7.Text = "IT";
            this.rb7.UseVisualStyleBackColor = true;
            // 
            // rb6
            // 
            this.rb6.AutoSize = true;
            this.rb6.Location = new System.Drawing.Point(17, 143);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(61, 16);
            this.rb6.TabIndex = 9;
            this.rb6.TabStop = true;
            this.rb6.Text = "スポーツ";
            this.rb6.UseVisualStyleBackColor = true;
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(17, 120);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(57, 16);
            this.rb5.TabIndex = 8;
            this.rb5.TabStop = true;
            this.rb5.Text = "エンタメ";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(17, 97);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(47, 16);
            this.rb4.TabIndex = 7;
            this.rb4.TabStop = true;
            this.rb4.Text = "経済";
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(17, 74);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(47, 16);
            this.rb3.TabIndex = 6;
            this.rb3.TabStop = true;
            this.rb3.Text = "国際";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(17, 51);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(47, 16);
            this.rb2.TabIndex = 5;
            this.rb2.TabStop = true;
            this.rb2.Text = "国内";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "決定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 683);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.tbUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb8;
        private System.Windows.Forms.RadioButton rb7;
        private System.Windows.Forms.RadioButton rb6;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.Button button1;
    }
}

