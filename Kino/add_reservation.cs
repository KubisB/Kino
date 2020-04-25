using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (comboBoxSala.SelectedIndex != -1 && comboBoxMiejsce.SelectedIndex != -1 && comboBoxSeans.SelectedIndex != -1
                && !string.IsNullOrWhiteSpace(textBoxNazwisko.Text) && !string.IsNullOrWhiteSpace(textBoxImie.Text)
                && !string.IsNullOrWhiteSpace(textBoxMail.Text) && !string.IsNullOrWhiteSpace(textBoxTel.Text))
            {
                Regex rg = new Regex(@"[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtQqUuWwYyZzŹźŻż]");
                if (rg.IsMatch(textBoxNazwisko.Text) && rg.IsMatch(textBoxImie.Text))
                {
                    rg = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
                    if (rg.IsMatch(textBoxMail.Text))
                    {
                        rg = new Regex(@"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$");
                        if (rg.IsMatch(textBoxTel.Text))
                        {
                            new_reservation.Id_reservation = rezerwacja.ListaRezerwacji.Count + 1;
                            
                            new_reservation.Nazwisko = textBoxNazwisko.Text;
                            new_reservation.Imie = textBoxImie.Text;
                            new_reservation.Mail = textBoxMail.Text;
                            new_reservation.NrTel = textBoxTel.Text;
                        }
                        else
                        {
                            MessageBox.Show("Źle wypełniono polę numer telefonu!");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Źle wypełniono polę e-mail!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Źle wypełniono polę imię lub nazwisko!");
                    return;
                }
                

                new_reservation.Miejsce = Int32.Parse(comboBoxMiejsce.SelectedItem.ToString());
                foreach (seans s in seans.ListaSeansow)
                {
                    int nrSeansu = Int32.Parse(comboBoxSeans.SelectedItem.ToString().Split('"')[0]);
                    if (nrSeansu == s.Nrseansu)
                    {
                        new_reservation.Seans = s;
                        if (s.S.ListaMiejscWsali1[(Int32.Parse(comboBoxMiejsce.SelectedItem.ToString()) - 1)].Statusmiejsca)
                        {
                            new_reservation.Miejsce = s.S.ListaMiejscWsali1[(Int32.Parse(comboBoxMiejsce.SelectedItem.ToString()) - 1)].Nrmiejsca;
                            s.S.ListaMiejscWsali1[(Int32.Parse(comboBoxMiejsce.SelectedItem.ToString()) - 1)].Statusmiejsca = false;
                        }
                    }
                }
                new_reservation.Aktywna = true;
                zamykanie = true;
                DialogResult = DialogResult.OK;
                comboBoxSala.Items.Clear();
                comboBoxMiejsce.Items.Clear();
                comboBoxSeans.Items.Clear();
                Close();
            }
            else
            {
                zamykanie = false;
                MessageBox.Show("Nie uzupełniono wszystkich pól!");
                
            }
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
                //if(s.S.Nrsali == Int32.Parse(comboBoxSala.SelectedItem.ToString()))
                //{
                //    for (int i = 1; i <= s.S.Iloscmiejsce; i++)
                //    {
                //        if(s.S.ListaMiejscWsali1[i].Statusmiejsca)
                //            comboBoxMiejsce.Items.Add(i);
                //    }
                //}
                if (s.Nrseansu == Int32.Parse(comboBoxSeans.SelectedItem.ToString().Split('"')[0]))
                {
                    foreach (miejsce m in s.S.ListaMiejscWsali1)
                    {
                        if (m.Statusmiejsca)
                        {
                            comboBoxMiejsce.Items.Add(m.Nrmiejsca);
                        }
                    }
                }
            }
        }
    }
}
