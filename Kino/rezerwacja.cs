using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class rezerwacja:klient
    {
        public static List<rezerwacja> ListaRezerwacji = new List<rezerwacja>();
        private int id_reservation;
        private int rzad;
        private int miejsce;
      // private klient klient;
        private seans seans;
        private bool aktywna;

        public int Id_reservation { get => id_reservation; set => id_reservation = value; }
        public seans Seans { get => seans; set => seans = value; }
        public int Rzad { get => rzad; set => rzad = value; }
        public int Miejsce { get => miejsce; set => miejsce = value; }
        //public klient Klient { get => klient; set => klient = value; }
        public bool Aktywna { get => aktywna; set => aktywna = value; }

        public void Anuluj_rez()
        {
            this.aktywna = false;
            seans.S.ListaMiejscWsali1[this.miejsce].Statusmiejsca = true;
        }
    }
}
