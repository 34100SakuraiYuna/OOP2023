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
        List<site> _favoriteSiteInfo = new List<site>();
        site sitedata;





        public Form1() {
            InitializeComponent();
        }


        public struct site {
            public string Link;
            public string Title;
            public string Text;
        }


        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            lbRssTitle.Items.Clear();

            try {
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
            } catch(System.Net.WebException) {
                return;
            } catch(System.ArgumentException) {
                return;
            }
        }


        //普通のタイトルをクリックした
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


        //決定ボタン
        private void btSelect_Click(object sender, EventArgs e) {
            var url = "";
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
        }


        //お気に入りボタン
        private void btOkini_Click(object sender, EventArgs e) {
            if(lbRssTitle.SelectedItem == null) {
                return;
            }

            foreach(var siteInfo in ItemDatas) {
                if(siteInfo.Title == lbRssTitle.SelectedItem.ToString()) {
                    if(_favoriteSiteInfo.Contains((site)lbRssTitle.SelectedItem)) {
                        sitedata = new site {
                            Link = siteInfo.Link,
                            Title = siteInfo.Title,
                            Text = siteInfo.Title
                        };

                        if(sitedata.Text.Length >= 17) {
                            sitedata.Text = sitedata.Text.Substring(0, 16) + "...";
                        }

                        lbFavoriteList.Items.Insert(0, sitedata.Text);
                        _favoriteSiteInfo.Add(sitedata);
                        break;
                    }
                }
            }
        }


        //お気に入り一覧のクリック
        private void lbFavoriteList_SelectedIndexChanged(object sender, EventArgs e) {
            if(lbFavoriteList == null) {
                return;
            }
            if(lbFavoriteList.SelectedIndex == -1) {
                return;
            }

            foreach(var item in _favoriteSiteInfo) {
                if(item.Text == lbFavoriteList.SelectedItem.ToString()) {
                    wbBrowser.Navigate(item.Link);
                }
            }
            lbRssTitle.ClearSelected();
        }


        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("この機能は実装されていません");
        }


    }
}
