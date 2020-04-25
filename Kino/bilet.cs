using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    class bilet
    {
        private int mrBiletu;
        private string typ;
        private double cena;

        public int MrBiletu { get => mrBiletu; set => mrBiletu = value; }
        public string Typ { get => typ; set => typ = value; }
        public double Cena { get => cena; set => cena = value; }
    }
}
