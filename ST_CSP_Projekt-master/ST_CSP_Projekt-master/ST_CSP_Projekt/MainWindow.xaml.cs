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
using System.IO;


namespace ST_CSP_Projekt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string PassSec(string pass)
        {
            char[] secret = pass.ToCharArray();

            for (int i = 0; i < secret.Length; i++)
            {
                secret[i] = (char)(secret[i] * 5);
            }
            string secpass = new string(secret);
            return secpass;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string nev = textBox1.Text;
            if (nev!="" & passwordBox1.Password!="")
            {
                if (File.Exists(nev + ".txt"))
                {
                    string x = File.ReadAllText(nev + ".txt");
                    string[] fajl = x.Split(';');
                    if (fajl[2] == passwordBox1.Password)
                    {
                        //igaz
                    }
                    else
                    {
                        MessageBox.Show("Hibás jelszó!");
                    }
                }
                else
                {
                    MessageBox.Show("Nincs ilyen felhasználó!");
                }
            }

            else
            {
                MessageBox.Show("Nincsenek adatok beírva!");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
