using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class film
    {
        public static List<film> ListaFilmów = new List<film>();
        private int nrfilmu;
        private string tytul;
        private double dlugosctrwaniaseansu;

        public int Nrfilmu { get => nrfilmu; set => nrfilmu = value; }
        public string Tytul { get => tytul; set => tytul = value; }
       
        public double Dlugosctrwaniaseansu { get => dlugosctrwaniaseansu; set => dlugosctrwaniaseansu = value; }
        
        

    }
}
