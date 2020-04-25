using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
   class miejsce
    {
        private int nrmiejsca;
        private bool statusmiejsca;

        public int Nrmiejsca { get => nrmiejsca; set => nrmiejsca = value; }
        public bool Statusmiejsca { get => statusmiejsca; set => statusmiejsca = value; }

        public void ZmianaStatusu() { }

    }
}
