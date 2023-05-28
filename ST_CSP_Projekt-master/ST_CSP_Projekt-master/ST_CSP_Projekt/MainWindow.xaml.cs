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
            bej_feh_input.Focus();
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

        private void bej_login_button_Click(object sender, RoutedEventArgs e)
        {
            string nev = bej_feh_input.Text;
            if (nev!="" & bej_jelszo_input.Password!="")
            {
                if (File.Exists(nev + ".txt"))
                {
                    string x = File.ReadAllText(nev + ".txt");
                    string[] fajl = x.Split(';');
                    if (fajl[2] == PassSec(bej_jelszo_input.Password))
                    {
                        MessageBox.Show("Sikeres bejelentkezés!");
                        Window2 ablak = new Window2();
                        ablak.Show();
                        Close();
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

        private void bej_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bej_register_Click(object sender, RoutedEventArgs e)
        {
            Bejelentkezes_Grid.Visibility = Visibility.Visible;
            Register_Grid.Visibility = Visibility.Visible;
            Bej_Logo_Grid.Visibility = Visibility.Visible;
        }

        private void bej_logo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Szeretünk Józsi Bácsi! ;)");
        }

        private void bej_web_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://premontrei-keszthely.hu");
        }

        private void bej_facebook_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Premontrei.Keszthely");
        }

        private void bej_insta_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/premontrei_kozepiskola/");
        }
        private void reg_logo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Szeretünk Józsi Bácsi! ;)");
        }

        private void reg_web_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://premontrei-keszthely.hu");
        }

        private void reg_facebook_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Premontrei.Keszthely");
        }

        private void reg_insta_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/premontrei_kozepiskola/");
        }
        private void reg_register_button_Click(object sender, RoutedEventArgs e)
        {
            string nem = "";
            string fnev = reg_felh_input.Text;
            string email = reg_email_input.Text;
            string jelszo = reg_pass_input.Password;
            string jelszo1 = reg_pass_again_input.Password;
            string file = fnev + ".txt";
            string kor = reg_age_input.Text;
            int kor1 = 0;



            if (fnev != "" & email != "" & jelszo != "" & jelszo1 != "")
            {
                if (int.TryParse(kor, out kor1))
                {
                    Szemely person = new Szemely(fnev, email, nem, jelszo, jelszo1, kor1);
                    if (jelszo == jelszo1)

                    {
                        if (person.Email.Contains("@") == true | person.Email.Contains(".") == true)
                        {
                            if (person.Kor < 100)
                            {
                                if (person.Jelszo.Length >= 8)
                                {
                                    if (person.Jelszo.Contains("$") == true | person.Jelszo.Contains("%") == true | person.Jelszo.Contains("#") == true | person.Jelszo.Contains("*") == true | person.Jelszo.Contains(".") == true)
                                    {
                                        if (reg_male.IsChecked == true)
                                        {
                                            nem = "Férfi";
                                            File.WriteAllText(file, person.Nev + ";" + person.Email + ";" + PassSec(person.Jelszo) + ";" + person.Kor + ";" + nem);
                                            MessageBox.Show("Sikeres regisztráció!");
                                            Register_Grid.Visibility = Visibility.Hidden;
                                            Bejelentkezes_Grid.Visibility = Visibility.Visible;
                                            Bej_Logo_Grid.Visibility = Visibility.Visible;
                                            Reg_Logo_Grid.Visibility = Visibility.Hidden;
                                        }
                                        else if (reg_female.IsChecked == true)
                                        {
                                            nem = "Nő";
                                            File.WriteAllText(file, person.Nev + ";" + person.Email + ";" + PassSec(person.Jelszo) + ";" + person.Kor + ";" + nem);
                                            MessageBox.Show("Sikeres regisztráció!");
                                            Register_Grid.Visibility = Visibility.Hidden;
                                            Bejelentkezes_Grid.Visibility = Visibility.Visible;
                                            Bej_Logo_Grid.Visibility = Visibility.Visible;
                                            Reg_Logo_Grid.Visibility = Visibility.Hidden;
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
                            MessageBox.Show("Az email cím nem tartalmaz @ vagy .-ot!");
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

        private void reg_back_button_Click(object sender, RoutedEventArgs e)
        {
            Register_Grid.Visibility = Visibility.Hidden;
            Bejelentkezes_Grid.Visibility = Visibility.Visible;
            Bej_Logo_Grid.Visibility = Visibility.Visible;
        }
    }
}

