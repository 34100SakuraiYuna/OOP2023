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
        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }


        //スライダーの色を返す
        public void backColor() {
            byte r = Convert.ToByte(rSlider.Value);
            byte g = Convert.ToByte(gSlider.Value);
            byte b = Convert.ToByte(bSlider.Value);

            var color = new SolidColorBrush(Color.FromRgb(r,g,b));
            colorArea.Background = color;
        }

        //スライダーが変わったときに呼ばれる
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            backColor();
        }


        //ストックボタンが押された時のやつ
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            string s = "R：" + rValue.Text + "　G：" + gValue.Text + "　B：" + bValue.Text;
            stockList.Items.Insert(0,s);
        }


        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var color = (MyColor)((ComboBox)sender).SelectedItem;
            var r = color.Color.R;
            var g = color.Color.G;
            var b = color.Color.B;

            var bColor = new SolidColorBrush(Color.FromRgb(r, g, b));

            colorArea.Background = bColor;   
        }


        public static void a() {
            
        }
    }


    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
    }
}
