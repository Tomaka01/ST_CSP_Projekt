using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_CSP_Projekt
{
    class Termek
    {
        string nev;
        int ar;

        public Termek(string nev, int ar)
        {
            this.Nev = nev;
            this.Ar = ar;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Ar { get => ar; set => ar = value; }
    }
}
