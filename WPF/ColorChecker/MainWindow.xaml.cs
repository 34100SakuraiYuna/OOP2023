using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Drawing;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        string _colorR = "0";
        string _colorG = "0";
        string _colorB = "0";
        IDictionary<string, Color> colorInfoMap = new Dictionary<string, Color>();


        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
            GetColorInfo();
        }


        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }


        //色の名前とRGB値の一覧を作る
        public void GetColorInfo() {
            MyColor[] colors = GetColorList();
            foreach(var item in colors) {
                colorInfoMap.Add(item.Name, item.Color);
            }
        }


        //スライダーが変わったときに呼ばれる
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            BackColor();
        }


        //コンボボックスで色を変える
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var color = (MyColor)((ComboBox)sender).SelectedItem;

            rValue.Text = color.Color.R.ToString();
            gValue.Text = color.Color.G.ToString();
            bValue.Text = color.Color.B.ToString();
        }


        //バックcolorを変える
        public void BackColor() {
            byte r = Convert.ToByte(rSlider.Value);
            byte g = Convert.ToByte(gSlider.Value);
            byte b = Convert.ToByte(bSlider.Value);

            var color = new SolidColorBrush(Color.FromRgb(r, g, b));
            colorArea.Background = color;

            SetFieldRgb(r.ToString(), g.ToString(), b.ToString());
        }


        //ストックボタンが押された時のやつ
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var stockName = "";

            foreach(var color in colorInfoMap) {
                if(color.Value.R.ToString() == _colorR && color.Value.G.ToString() == _colorG && color.Value.B.ToString() == _colorB) {
                    stockName = color.Key;
                    break;
                } else {
                    stockName = "R：" + rValue.Text + "　G：" + gValue.Text + "　B：" + bValue.Text;
                }
            }
            stockList.Items.Insert(0, stockName);
        }


        //stockListが選択された
        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var itemText = stockList.SelectedItem.ToString();
            for(int i = 0; i < 3; i++) {
                SetRgb(itemText);

                rValue.Text = _colorR;
                gValue.Text = _colorG;
                bValue.Text = _colorB;
            }
        }


        //引数(string)のRGB値と名前をフィールド変数に入れる
        public void SetRgb(string text) {
            foreach(var item in colorInfoMap) {
                if(Regex.IsMatch(text, "^[A-Z][a-z]+[A-Za-z]*")) {
                    if(item.Key == text) {
                        SetFieldRgb(item.Value.R.ToString(), item.Value.G.ToString(), item.Value.B.ToString());
                        break;
                    }
                } else {
                    string[] rgbPrameters = text.Split('　', '：');
                    SetFieldRgb(rgbPrameters[1], rgbPrameters[3], rgbPrameters[5]);
                    break;
                }
            }
        }


        //_colorRGBに値をセットする
        public void SetFieldRgb(string r,string g,string b) {
            _colorR = r;
            _colorG = g;
            _colorB = b;
        }
    }


    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
    }
}
