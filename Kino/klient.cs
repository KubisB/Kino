using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    class klient
    {
        public static List<klient> listaKlientow = new List<klient>();
        private int nrKlienta;
        private string imie, nazwisko, mail, nrTel;

        public int NrKlienta { get => nrKlienta; set => nrKlienta = value; }
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Mail { get => mail; set => mail = value; }
        public string NrTel { get => nrTel; set => nrTel = value; }
    }
}
