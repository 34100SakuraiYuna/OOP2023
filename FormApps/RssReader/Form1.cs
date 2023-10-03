using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        //IEnumerable<ItemData> nodes;

        //模範解答
        List<ItemData> ItemDatas = new List<ItemData>();

        public Form1() {
            InitializeComponent();
            urlSelect();
        }


        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            if(tbUrl.Text == "") {
                return;
            }
            
            using(var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url);

                ItemDatas = xdoc.Root.Descendants("item").Select(x => new ItemData {
                    Title = (string)x.Element("title"),
                    Link = (string)x.Element("link")
                }).ToList();

                foreach(var node in ItemDatas) {
                    lbRssTitle.Items.Add(node.Title);
                }
            }
        }


        //タイトルをクリックした
        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if(lbRssTitle == null) {
                return;
            }
            var num = lbRssTitle.SelectedIndex;
            wbBrowser.Navigate(ItemDatas[num].Link);
        }


        //ラジオボタン
        public void urlSelect() {
            string url = "https://news.yahoo.co.jp/rss/topics/top-picks.xml";
            if(rb1.Checked) {
            } else if(rb2.Checked) {
            } else if(rb3.Checked) {
            } else if(rb4.Checked) {
            } else if(rb5.Checked) {
            } else if(rb6.Checked) {
            } else if(rb7.Checked) {
            } else if(rb8.Checked) {
            } else {
            }
            tbUrl.Text = url;
        }
    }
}
