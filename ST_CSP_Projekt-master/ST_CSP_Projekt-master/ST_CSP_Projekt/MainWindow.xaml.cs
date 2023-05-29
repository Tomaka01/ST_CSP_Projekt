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
        public List<string> foods = new List<string>();
        public int osszegdb = 0;
        public int osszeg = 0;
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
                        Alap_Grid.Visibility = Visibility.Visible;
                        Bejelentkezes_Grid.Visibility = Visibility.Hidden;
                        Bej_Logo_Grid.Visibility = Visibility.Hidden;
                        Register_Grid.Visibility = Visibility.Hidden;
                        Reg_Logo_Grid.Visibility = Visibility.Hidden;
                        Shop1_Grid.Visibility = Visibility.Visible;
                        Shop1_Logo_Grid.Visibility = Visibility.Visible;
                        Shop2_Grid.Visibility = Visibility.Hidden;
                        Shop2_Logo_Grid.Visibility = Visibility.Hidden;
                        Kosar_Grid.Visibility = Visibility.Hidden;
                        Kosar_Logo_Grid.Visibility = Visibility.Hidden;
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
            Reg_Logo_Grid.Visibility = Visibility.Visible;
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
                        if (person.Email.Contains("@") == true & person.Email.Contains(".") == true)
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
        private void shop1_next_button_Click(object sender, RoutedEventArgs e)
        {
            Shop1_Grid.Visibility = Visibility.Hidden;
            Kosar_Grid.Visibility = Visibility.Hidden;
            Shop2_Grid.Visibility = Visibility.Visible;
            Kosar_Logo_Grid.Visibility = Visibility.Hidden;
            Shop2_Logo_Grid.Visibility = Visibility.Visible;
            Shop1_Logo_Grid.Visibility = Visibility.Hidden;
        }

        private void shop1_kosar_Click(object sender, RoutedEventArgs e)
        {
            kosar_osszeg.Text = "Végösszeg: " + osszeg + " Ft \t" + "Termékek száma: " + osszegdb + " db";
            Shop1_Grid.Visibility = Visibility.Hidden;
            Kosar_Grid.Visibility = Visibility.Visible;
            Shop2_Grid.Visibility = Visibility.Hidden;
            Kosar_Logo_Grid.Visibility = Visibility.Visible;
            Shop2_Logo_Grid.Visibility = Visibility.Hidden;
            Shop1_Logo_Grid.Visibility = Visibility.Hidden;
        }

        private void shop2_kilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void etel1gomb_Click(object sender, RoutedEventArgs e)
        {
            osszegdb++;
            osszeg += 2300;
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
            osszegdb++;
            osszeg += 2000;
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

        private void kosar_back_Click_1(object sender, RoutedEventArgs e)
        {
            Shop1_Grid.Visibility = Visibility.Visible;
            Kosar_Grid.Visibility = Visibility.Hidden;
            Shop2_Grid.Visibility = Visibility.Hidden;
            Kosar_Logo_Grid.Visibility = Visibility.Hidden;
            Shop2_Logo_Grid.Visibility = Visibility.Hidden;
            Shop1_Logo_Grid.Visibility = Visibility.Visible;
        }

        private void etel3gomb_Click(object sender, RoutedEventArgs e)
        {
            osszegdb++;
            osszeg += 3000;
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
            osszegdb++;
            osszeg += 3200;
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
            osszegdb++;
            osszeg += 2200;
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
            osszegdb++;
            osszeg += 4200;
            foods.Add("Sült csirke");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel6 = 0;
            etel6 = foods.Count(x => x == "Sült csirke");
            if (etel6 > 0)
            {
                if (etel6 > 1)
                {
                    etelkosar.Items.Remove("Sült csirke " + (etel6 - 1) + " db " + ((4200 * etel6) - 4200) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Sült csirke " + etel6 + " db " + (4200 * etel6) + "Ft" + "\t");

            }
        }

        private void etel7gomb_Click(object sender, RoutedEventArgs e)
        {
            osszegdb++;
            osszeg += 1700;
            foods.Add("Bolognai Spaghetti");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel7 = 0;
            etel7 = foods.Count(x => x == "Bolognai Spaghetti");
            if (etel7 > 0)
            {
                if (etel7 > 1)
                {
                    etelkosar.Items.Remove("Bolognai Spaghetti " + (etel7 - 1) + " db " + ((1700 * etel7) - 1700) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Bolognai Spaghetti " + etel7 + " db " + (1700 * etel7) + "Ft" + "\t");

            }
        }

        private void etel8gomb_Click(object sender, RoutedEventArgs e)
        {
            osszegdb++;
            osszeg += 1500;
            foods.Add("Gyros Pita");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel8 = 0;
            etel8 = foods.Count(x => x == "Gyros Pita");
            if (etel8 > 0)
            {
                if (etel8 > 1)
                {
                    etelkosar.Items.Remove("Gyros Pita " + (etel8 - 1) + " db " + ((1500 * etel8) - 1500) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Gyros Pita " + etel8 + " db " + (1500 * etel8) + "Ft" + "\t");

            }
        }

        private void etel9gomb_Click(object sender, RoutedEventArgs e)
        {
            osszegdb++;
            osszeg += 3600;
            foods.Add("Biryani");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel9 = 0;
            etel9 = foods.Count(x => x == "Biryani");
            if (etel9 > 0)
            {
                if (etel9 > 1)
                {
                    etelkosar.Items.Remove("Biryani " + (etel9 - 1) + " db " + ((3600 * etel9) - 3600) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Biryani " + etel9 + " db " + (3600 * etel9) + "Ft" + "\t");

            }
        }

        private void etel10gomb_Click(object sender, RoutedEventArgs e)
        {
            osszegdb++;
            osszeg += 800;
            foods.Add("Coca Cola");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel10 = 0;
            etel10 = foods.Count(x => x == "Coca Cola");
            if (etel10 > 0)
            {
                if (etel10 > 1)
                {
                    etelkosar.Items.Remove("Coca Cola " + (etel10 - 1) + " db " + ((800 * etel10) - 800) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Coca Cola " + etel10 + " db " + (800 * etel10) + "Ft" + "\t");

            }
        }

        private void etel11gomb_Click(object sender, RoutedEventArgs e)
        {
            osszegdb++;
            osszeg += 800;
            foods.Add("Sprite");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel11 = 0;
            etel11 = foods.Count(x => x == "Sprite");
            if (etel11 > 0)
            {
                if (etel11 > 1)
                {
                    etelkosar.Items.Remove("Sprite " + (etel11 - 1) + " db " + ((800 * etel11) - 800) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Sprite " + etel11 + " db " + (800 * etel11) + "Ft" + "\t");

            }
        }

        private void etel12gomb_Click(object sender, RoutedEventArgs e)
        {
            osszegdb++;
            osszeg += 500;
            foods.Add("Ásványvíz");
            MessageBox.Show("A termék hozzá lett adva a kosárhoz!");
            int etel12 = 0;
            etel12 = foods.Count(x => x == "Ásványvíz");
            if (etel12 > 0)
            {
                if (etel12 > 1)
                {
                    etelkosar.Items.Remove("Ásványvíz " + (etel12 - 1) + " db " + ((500 * etel12) - 500) + "Ft" + "\t");
                }
                etelkosar.Items.Add("Ásványvíz " + etel12 + " db " + (500 * etel12) + "Ft" + "\t");

            }
        }

        private void shop2_back_button_Click(object sender, RoutedEventArgs e)
        {
            Shop1_Grid.Visibility = Visibility.Visible;
            Kosar_Grid.Visibility = Visibility.Hidden;
            Shop2_Grid.Visibility = Visibility.Hidden;
            Kosar_Logo_Grid.Visibility = Visibility.Hidden;
            Shop2_Logo_Grid.Visibility = Visibility.Hidden;
            Shop1_Logo_Grid.Visibility = Visibility.Visible;
        }

        private void shop2_kosar_Click(object sender, RoutedEventArgs e)
        {
            kosar_osszeg.Text = "Végösszeg: " + osszeg + " Ft \t" + "Termékek száma: " + osszegdb + " db";
            Shop1_Grid.Visibility = Visibility.Hidden;
            Kosar_Grid.Visibility = Visibility.Visible;
            Shop2_Grid.Visibility = Visibility.Hidden;
            Kosar_Logo_Grid.Visibility = Visibility.Visible;
            Shop2_Logo_Grid.Visibility = Visibility.Hidden;
            Shop1_Logo_Grid.Visibility = Visibility.Hidden;
        }

        private void kosar_rendeles_Click(object sender, RoutedEventArgs e)
        {
            int iranyito1 = 0;
            string iranyito = kosar_irszam_input.Text;
            int hazszam1 = 0;
            string hazszam = kosar_hazszam_input.Text;
            if (kosar_telepules_input.Text != "" & kosar_irszam_input.Text != "" & kosar_utca_input.Text != "" & kosar_hazszam_input.Text != "" & kosar_keszpenz.IsChecked == true | kosar_kartya.IsChecked == true)
            {
                if (int.TryParse(iranyito, out iranyito1))
                {
                    if (int.TryParse(hazszam, out hazszam1))
                    {
                        if (kosar_irszam_input.Text.Length == 4)
                        {
                            MessageBox.Show("A rendelés leadva!");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Az irányítószám 4 karakterből kell hogy álljon!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ez a mező csak számot tartalmazhat!");
                    }

                }
                else
                {
                    MessageBox.Show("Az irányítószámban nem lehet betű!");
                }

            }
            else
            {
                MessageBox.Show("Nincsenek adatok megadva!");
            }

        }

        private void kosar_delete_Click(object sender, RoutedEventArgs e)
        {
            etelkosar.Items.Clear();
            kosar_osszeg.Text = "Végösszeg: 0 Ft " + " " +" \t"+ "Termékek száma: 0 db";
            osszegdb = 0;
            osszeg = 0;
            foods.Clear();
        }



        private void shop1_kilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void shop2_web_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://premontrei-keszthely.hu");
        }

        private void shop2_facebook_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Premontrei.Keszthely");
        }

        private void shop2_insta_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/premontrei_kozepiskola/");
        }

        private void shop1_logo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Szeretünk Józsi Bácsi! ;)");
        }

        private void shop1_web_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://premontrei-keszthely.hu");
        }

        private void shop1_facebook_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Premontrei.Keszthely");
        }

        private void shop1_insta_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/premontrei_kozepiskola/");
        }


        private void kosar_web_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://premontrei-keszthely.hu");
        }

        private void kosar_facebook_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Premontrei.Keszthely");
        }

        private void kosar_insta_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/premontrei_kozepiskola/");
        }

        private void kosar_logo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Szeretünk Józsi Bácsi! ;)");
        }

        private void shop2_logo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Szeretünk Józsi Bácsi! ;)");
        }

        private void kosar_user_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shop1_user_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shop2_user_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}