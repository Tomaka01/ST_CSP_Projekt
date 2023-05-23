using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_CSP_Projekt
{
    class Szemely
    {
        string nev, email, nem, jelszo, jelszo1;
        int kor;

        public Szemely(string nev, string email, string nem, string jelszo, string jelszo1, int kor)
        {
            this.Nev = nev;
            this.Email = email;
            this.Nem = nem;
            this.Jelszo = jelszo;
            this.Jelszo1 = jelszo1;
            this.Kor = kor;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Email { get => email; set => email = value; }
        public string Nem { get => nem; set => nem = value; }
        public string Jelszo { get => jelszo; set => jelszo = value; }
        public string Jelszo1 { get => jelszo1; set => jelszo1 = value; }
        public int Kor { get => kor; set => kor = value; }
    }
}
