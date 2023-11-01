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
            _colorName = null;
        }


        //ストックボタンが押された時のやつ
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            string s = "";
            foreach(var item in GetColorList()) {
                if(_colorName == item.Name) {
                    stockList.Items.Insert(0, _colorName);
                    break;
                }
            }

            s = "R：" + rValue.Text + "　G：" + gValue.Text + "　B：" + bValue.Text;
            stockList.Items.Insert(0, s);
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
    }


    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
    }
}
