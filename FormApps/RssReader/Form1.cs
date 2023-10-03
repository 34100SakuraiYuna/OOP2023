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
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        IEnumerable<ItemData> nodes;
        

        public Form1() {
            InitializeComponent();
        }


        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            using(var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url);

                nodes = xdoc.Root.Descendants("item").Select(x => new ItemData {
                    Title = (string)x.Element("title"),
                    Link = (string)x.Element("link")
                });

                foreach(var node in nodes) {
                    lbRssTitle.Items.Add(node.Title);
                }
            }
        }


        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            foreach(var item in nodes) {
                if(sender.ToString().Contains(item.Title)) {
                    wbBrowser.Navigate(item.Link);
                }
            }
        }
    }
}
