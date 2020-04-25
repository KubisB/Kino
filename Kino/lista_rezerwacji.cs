using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    public partial class lista_rezerwacji : Form
    {
        public lista_rezerwacji()
        {
            InitializeComponent();
        }

        private void lista_rezerwacji_Load(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            listBox1.Items.Clear();

            foreach (rezerwacja r in rezerwacja.ListaRezerwacji)
            {
                if (r.Aktywna)
                {
                    listBox1.Items.Add(r.Id_reservation + " - " + r.Seans.F.Tytul + " - " + r.Seans.Godzinarozpoczecia() + " - " + r.Miejsce + " - " + r.Nazwisko);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (rezerwacja r in rezerwacja.ListaRezerwacji)
                {
                    if (r.Id_reservation == Int32.Parse(listBox1.SelectedItem.ToString().Split('-')[0]))
                    {
                        r.Anuluj_rez();
                        r.Seans.S.ListaMiejscWsali1[r.Miejsce].Statusmiejsca = true;
                        MessageBox.Show("Anulowano rezerwację o id: " + r.Id_reservation);
                    }
                }
                refresh();
            }
            catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
