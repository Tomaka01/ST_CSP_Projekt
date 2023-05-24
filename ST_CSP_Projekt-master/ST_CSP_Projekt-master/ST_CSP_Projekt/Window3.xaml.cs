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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void vissza_Click(object sender, RoutedEventArgs e)
        {
            Window2 akabsz = new Window2();
            akabsz.Show();
            Close();
        }

        private void kosar_Click(object sender, RoutedEventArgs e)
        {
            Window4 ablaksz = new Window4();
            ablaksz.Show();
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
