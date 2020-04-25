using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class seans
    {
        public static List<seans> ListaSeansow = new List<seans>();
        private int nrseansu;
        private Sala s;
        private film f;
        private DateTime data_godz;
        public int Nrseansu { get => nrseansu; set => nrseansu = value; }
        public Sala S { get => s; set => s = value; }
        public film F { get => f; set => f = value; }
        public DateTime Data_godz { get => data_godz; set => data_godz = value; }
        public string Data() { return this.Data_godz.Year.ToString() + "/" + this.Data_godz.Month.ToString() + "/" + this.Data_godz.Day.ToString(); }
        public string Godzinarozpoczecia() { return this.Data_godz.Hour.ToString() + ":" + this.Data_godz.Minute.ToString(); }
        public TimeSpan Godzinazakonczenia() { return Data_godz.TimeOfDay + TimeSpan.FromMinutes(f.Dlugosctrwaniaseansu); }

    }
}
