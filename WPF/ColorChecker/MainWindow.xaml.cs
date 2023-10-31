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


        public SolidColorBrush backColor() {
            byte r = Convert.ToByte(rSlider.Value);
            byte g = Convert.ToByte(gSlider.Value);
            byte b = Convert.ToByte(bSlider.Value);

            var color = new SolidColorBrush(Color.FromRgb(r,g,b));
            colorArea.Background = color;

            return color;
        }


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            backColor();
        }


        //
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            string s = ("R：" + rValue.Text + "　G：" + gValue.Text + "　B：" + bValue.Text);
            stockList.Items.Insert(0,s);
        }


        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }
    }


    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
    }

}
