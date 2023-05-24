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
using System.Windows.Shapes;

namespace ST_CSP_Projekt
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public List<string> foods = new List<string>();
        public Window2()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window3 abaksz = new Window3();
            abaksz.Show();
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window4 ablaksz = new Window4();
            ablaksz.Show();
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void etel1gomb_Click(object sender, RoutedEventArgs e)
        {
            foods.Add("");
        }
    }
}
