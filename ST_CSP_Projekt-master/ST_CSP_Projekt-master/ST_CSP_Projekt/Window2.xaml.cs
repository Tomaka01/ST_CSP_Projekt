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
            Gridgomb.Visibility = Visibility.Visible;
            Kosar.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Gridgomb.Visibility = Visibility.Hidden;
            Kosar.Visibility = Visibility.Visible;

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void etel1gomb_Click(object sender, RoutedEventArgs e)
        {
            foods.Add("Pizza");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel1 = 0;
            etel1 = foods.Count(x => x == "Pizza");
            if (etel1 > 0)
            {
                if (etel1 > 1)
                {
                    etelkosar.Items.Remove("Pizza " + (etel1 - 1) + " db " + ((2300 * etel1) - 2300) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Pizza " + etel1 + " db " + (2300 * etel1) + "Ft" + "\t");

            }
        }

        private void etel2gomb_Click(object sender, RoutedEventArgs e)
        {
            foods.Add("Hamburger");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel2 = 0;
            etel2 = foods.Count(x => x == "Hamburger");
            if (etel2 > 0)
            {
                if (etel2 > 1)
                {
                    etelkosar.Items.Remove("Hamburger " + (etel2 - 1) + " db " + ((2000 * etel2) - 2000) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Hamburger " + etel2 + " db " + (2000 * etel2) + "Ft" + "\t");

            }
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            Gridgomb.Visibility = Visibility.Visible;
            Kosar.Visibility = Visibility.Hidden;
        }

        private void etel3gomb_Click(object sender, RoutedEventArgs e)
        {
            foods.Add("Sushi");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel3 = 0;
            etel3 = foods.Count(x => x == "Sushi");
            if (etel3 > 0)
            {
                if (etel3 > 1)
                {
                    etelkosar.Items.Remove("Sushi " + (etel3 - 1) + " db " + ((3000 * etel3) - 3000) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Sushi " + etel3 + " db " + (3000 * etel3) + "Ft" + "\t");

            }
        }

        private void etel4gomb_Click(object sender, RoutedEventArgs e)
        {
            foods.Add("Thai curry");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel4 = 0;
            etel4 = foods.Count(x => x == "Thai curry");
            if (etel4 > 0)
            {
                if (etel4 > 1)
                {
                    etelkosar.Items.Remove("Thai curry " + (etel4 - 1) + " db " + ((3200 * etel4) - 3200) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Thai curry " + etel4 + " db " + (3200 * etel4) + "Ft" + "\t");

            }
        }

        private void etel5gomb_Click(object sender, RoutedEventArgs e)
        {
            foods.Add("Tacos");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel5 = 0;
            etel5 = foods.Count(x => x == "Tacos");
            if (etel5 > 0)
            {
                if (etel5 > 1)
                {
                    etelkosar.Items.Remove("Tacos " + (etel5 - 1) + " db " + ((2200 * etel5) - 2200) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Tacos " + etel5 + " db " + (2200 * etel5) + "Ft" + "\t");

            }
        }

        private void etel6gomb_Click(object sender, RoutedEventArgs e)
        {
            foods.Add("Sült csirke");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel6 = 0;
            etel6 = foods.Count(x => x == "Sült csirke");
            if (etel6 > 0)
            {
                if (etel6 > 1)
                {
                    etelkosar.Items.Remove("Sült csirke " + (etel6 - 1) + " db " + ((4000 * etel6) - 4000) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Sült csirke " + etel6 + " db " + (4000 * etel6) + "Ft" + "\t");

            }
        }
    }
}
