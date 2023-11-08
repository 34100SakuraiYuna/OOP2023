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
        }


        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            #region
            //if(tbUrl.Text == "") {
            //    return;
            //}
            //lbRssTitle.Items.Clear();   //リストボックスのクリア

            //using(var wc = new WebClient()) {
            //    var url = wc.OpenRead(tbUrl.Text);
            //    XDocument xdoc = XDocument.Load(url);

            //    ItemDatas = xdoc.Root.Descendants("item").Select(x => new ItemData {
            //        Title = (string)x.Element("title"),
            //        Link = (string)x.Element("link")
            //    }).ToList();

            //    foreach(var node in ItemDatas) {
            //        lbRssTitle.Items.Add(node.Title);
            //    }
            //}
            #endregion

            lbRssTitle.Items.Clear();

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
            if(lbRssTitle.SelectedIndex == -1) {
                return;
            }

            var num = lbRssTitle.SelectedIndex;
            wbBrowser.Navigate(ItemDatas[num].Link);
            lbFavoriteList.ClearSelected();
        }

        private void button1_Click(object sender, EventArgs e) {
            var url = "https://news.yahoo.co.jp/rss/topics/";
            //string url = "https://news.yahoo.co.jp/rss/topics/top-picks.xml";
            if(rb1.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/top-picks.xml";
            } else if(rb2.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/domestic.xml";
            } else if(rb3.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/world.xml";
            } else if(rb4.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/business.xml"; 
            } else if(rb5.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/entertainment.xml";
            } else if(rb6.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/sports.xml";
            } else if(rb7.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/it.xml";
            } else if(rb8.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/science.xml";
            } else if(rb9.Checked) {
                url = "https://news.yahoo.co.jp/rss/topics/local.xml";
            } else {
                url = "URLが取得できません";
            }

            tbUrl.Text = url;
            //getUrl();
        }


        private string[] getUrl() {
            var urls = new string[8];
            XDocument xdoc = XDocument.Load("https://news.yahoo.co.jp/rss/topics/top-picks.xml");
            ItemDatas = xdoc.Root.Descendants("item").Select(x => new ItemData {
                Title = (string)x.Element("title"),
                Link = (string)x.Element("link")
            }).ToList();
            
            return urls;
        }

        private void btOkini_Click(object sender, EventArgs e) {
            var a = lbRssTitle.SelectedItem;
            lbFavoriteList.Items.Insert(0,a);
        }


        //
        private void lbFavoriteList_SelectedIndexChanged(object sender, EventArgs e) {
            if(lbFavoriteList == null) {
                return;
            }
            if(lbFavoriteList.SelectedIndex == -1) {
                return;
            }

            var num = lbFavoriteList.SelectedIndex;
            wbBrowser.Navigate(ItemDatas[num].Link);
            lbRssTitle.ClearSelected();
        }
    }
}
