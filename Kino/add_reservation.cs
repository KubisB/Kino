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
    public partial class add_reservation : Form
    {
        private rezerwacja new_reservation;
        bool zamykanie;
        public add_reservation(rezerwacja res)
        {
            InitializeComponent();
            this.new_reservation = res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zamykanie = true;
            DialogResult = DialogResult.Cancel;
            comboBoxSala.Items.Clear();
            comboBoxMiejsce.Items.Clear();
            comboBoxSeans.Items.Clear();
            Close();

        }

        private void add_reservation_Load(object sender, EventArgs e)
        {
            foreach (Sala s in Sala.ListaSal)
            {
                for(int i = 1; i <= Sala.ListaSal.Count; i++) 
                {
                    comboBoxSala.Items.Add(s.Nrsali);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxSala.SelectedIndex == -1 || comboBoxMiejsce.SelectedIndex == -1 || comboBoxSeans.SelectedIndex == -1 || string.IsNullOrWhiteSpace(textBoxNazwisko.Text))
            {
                zamykanie = false;
            }
            else
            {
                zamykanie = true;
            }
            new_reservation.Id_reservation = rezerwacja.ListaRezerwacji.Count + 1;
            if(klient.listaKlientow.Count == 0) { 
                new_reservation.Klient.NrKlienta = 1;
            }
            else
            {
                new_reservation.Klient.NrKlienta = klient.listaKlientow.Count + 1;

            }
            new_reservation.Klient.Nazwisko = textBoxNazwisko.Text;
            new_reservation.Klient.Imie = textBoxImie.Text;
            new_reservation.Klient.Mail = textBoxMail.Text;
            new_reservation.Klient.NrTel = textBoxTel.Text;
            
            new_reservation.Miejsce = Int32.Parse(comboBoxMiejsce.SelectedItem.ToString());
            foreach (seans s in seans.ListaSeansow)
            {
                int nrSeansu = Int32.Parse(comboBoxSeans.SelectedItem.ToString().Split('"')[0]);
                if (nrSeansu == s.Nrseansu)
                {
                    new_reservation.Seans = s;
                    if (s.S.ListaMiejscWsali1[Int32.Parse(comboBoxMiejsce.SelectedItem.ToString())].Statusmiejsca)
                    {
                        new_reservation.Miejsce = s.S.ListaMiejscWsali1[Int32.Parse(comboBoxMiejsce.SelectedItem.ToString())].Nrmiejsca;
                    }
                }
            }
            DialogResult = DialogResult.OK;
            comboBoxSala.Items.Clear();
            comboBoxMiejsce.Items.Clear();
            comboBoxSeans.Items.Clear();
            Close();
        }

        private void add_reservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!zamykanie)
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
                e.Cancel = true;
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (seans s in seans.ListaSeansow)
            {
                if(s.S.Nrsali == Int32.Parse(comboBoxSala.SelectedItem.ToString()))
                {
                    comboBoxSeans.Items.Add(s.Nrseansu.ToString() + " \"" + s.F.Tytul.ToString() + "\"" + s.Godzinarozpoczecia().ToString());
                }
            }
        }

        private void comboBoxSeans_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (seans s in seans.ListaSeansow)
            {
                if(s.S.Nrsali == Int32.Parse(comboBoxSala.SelectedItem.ToString()))
                    {
                        for (int i = 1; i < s.S.Iloscmiejsce; i++)
                        {
                            if(s.S.ListaMiejscWsali1[i].Statusmiejsca)
                                comboBoxMiejsce.Items.Add(i);
                        }
                }
            }
        }
    }
}
