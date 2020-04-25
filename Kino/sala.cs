using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino {
    public class Sala
    {
        public static List<Sala> ListaSal = new List<Sala>();
        private int nrsali, iloscmiejsce, iloscrzedow;
        private string obraz;
        private List<miejsce> ListaMiejscWsali = new List<miejsce>();

       
        public string Obraz { get => obraz; set => obraz = value; }
        internal List<miejsce> ListaMiejscWsali1 { get => ListaMiejscWsali; set => ListaMiejscWsali = value; }
        public int Nrsali { get => nrsali; set => nrsali = value; }
        public int Iloscmiejsce { get => iloscmiejsce; set => iloscmiejsce = value; }
        public int Iloscrzedow { get => iloscrzedow; set => iloscrzedow = value; }

        public void Miejsca(){
            for(int i = 1; i <= this.Iloscmiejsce;i++)
            {
                miejsce m = new miejsce();
                m.Nrmiejsca = i;
                m.Statusmiejsca = true;
                this.ListaMiejscWsali1.Add(m);
            }
        }


    }
}
