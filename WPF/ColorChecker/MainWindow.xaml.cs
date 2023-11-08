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
        string _colorName;
        byte _colorR;
        byte _colorG;
        byte _colorB;


        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }


        //バックcolorを変える
        public void backColor() {
            _colorR = Convert.ToByte(rSlider.Value);
            _colorG = Convert.ToByte(gSlider.Value);
            _colorB = Convert.ToByte(bSlider.Value);

            var color = new SolidColorBrush(Color.FromRgb(_colorR, _colorG, _colorB));
            colorArea.Background = color;
        }


        //スライダーが変わったときに呼ばれる
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            backColor();
            //_colorName = null;
        }


        //ストックボタンが押された時のやつ
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            string str = "";

            if(_colorName != null) {
                stockList.Items.Insert(0,_colorName);
                _colorName = null;
            } else {
                str = "R：" + rValue.Text + "　G：" + gValue.Text + "　B：" + bValue.Text;
                stockList.Items.Insert(0, str);
            }
        }


        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }


        //コンボボックスで色を変える
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var color = (MyColor)((ComboBox)sender).SelectedItem;
            var bgColor = new SolidColorBrush(color.Color);

            colorArea.Background = bgColor;

            _colorName = color.Name;

            rValue.Text = color.Color.R.ToString();
            gValue.Text = color.Color.G.ToString();
            bValue.Text = color.Color.B.ToString();
        }


        public byte colorToByte(Color color) {
            byte b = 1;
            return b;
        }


        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var stockListText = stockList.SelectedItem.ToString();
            string[] colors = stockListText.Split('　','：');
            string[] colors2 = new string[3];
            int cnt = 0;
            for(int i = 0; i < colors.Length; i++) {
                if(i%2 == 1) {
                    colors2[cnt] = colors[i];
                    cnt++;
                }
            }

            rValue.Text = colors2[0];
            gValue.Text = colors2[1];
            bValue.Text = colors2[2];
        }


        private void stockList_SelectionChanged2(object sender, SelectionChangedEventArgs e) {
            var a = stockList.SelectedItem.ToString();
            string[] b = a.Split('　', '：');
            string[] c = new string[3];
            int cnt = 0;
            for(int i = 0; i < b.Length; i++) {
                if(i % 2 == 1) {
                    c[cnt] = b[i];
                    cnt++;
                }
            }

            rValue.Text = c[0];
            gValue.Text = c[1];
            bValue.Text = c[2];

            //var ColName = new ColorConverter().ConvertFromString(a);
            //Color w = Color.fromName(a);
        }


        public static void asdf() {
            IDictionary<string, int> map = new Dictionary<string, int>();
            var q = GetColorList();

        }

    }


    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
    }
}
