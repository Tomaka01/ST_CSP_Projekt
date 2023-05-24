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
using System.IO;

namespace ST_CSP_Projekt
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
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
            string nem = "";
            string fnev = textBox.Text;
            string email = textBox1.Text;
            string jelszo = passwordBox.Password;
            string jelszo1 = passwordBox1.Password;
            string file = fnev + ".txt";
            string kor = textBox2.Text;
            int kor1 = 0;



            if (fnev != "" & email != "" & jelszo != "" & jelszo1 != "")
            {
                if (int.TryParse(kor, out kor1))
                {
                    Szemely person = new Szemely(fnev, email, nem, jelszo, jelszo1, kor1);
                    if (jelszo == jelszo1)

                    {
                        if (person.Email.Contains("@")==true)
                        {
                            if (person.Kor<100)
                            {
                                if (person.Jelszo.Length>=8)
                                {
                                    if (person.Jelszo.Contains("$")==true | person.Jelszo.Contains("%") == true | person.Jelszo.Contains("#") == true | person.Jelszo.Contains("*") == true | person.Jelszo.Contains(".") == true)
                                    {
                                        if (radioButton.IsChecked == true)
                                        {
                                            nem = "Férfi";
                                            File.WriteAllText(file, person.Nev + ";" + person.Email + ";" + PassSec(person.Jelszo) + ";" + person.Kor + ";" + nem);
                                            MessageBox.Show("Sikeres regisztráció!");
                                            MainWindow w = new MainWindow();
                                            w.Show();
                                            Close();
                                        }
                                        else if (radioButton1.IsChecked == true)
                                        {
                                            nem = "Nő";
                                            File.WriteAllText(file, person.Nev + ";" + person.Email + ";" + PassSec(person.Jelszo) + ";" + person.Kor + ";" + nem);
                                            MessageBox.Show("Sikeres regisztráció!");
                                            MainWindow w = new MainWindow();
                                            w.Show();
                                            Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("A jelszónak tartalmaznia kell valamilyen különleges karaktert!($ % # * .)");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("A jelszónak legalább 8 karakterből kell állnia!");
                                }

                            }
                            else
                            {
                                MessageBox.Show("A kor nem lehet nagyobb 100-nál!");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Az email cím nem tartalmaz @-ot!");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Nem egyeznek a jelszavak");
                    }
                }
                else
                {
                    MessageBox.Show("A korban nem lehet betű!");
                }




            }
            else
            {
                MessageBox.Show("Nincsenek adatok beírva!");
            }

        }



        private void button3_Click(object sender, RoutedEventArgs e)
        {

            MainWindow abalksz = new MainWindow();
            abalksz.Show();
            Close();
        }
    }
}
