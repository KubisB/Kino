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
    public partial class new_seans : Form
    {
        private seans nowy_seans;
        bool zamykanie;
        public new_seans(seans nowy_seans)
        {
            InitializeComponent();
            this.nowy_seans = nowy_seans;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1){
                zamykanie = false;
            }
            else{
                zamykanie = true;
            }
            nowy_seans.Nrseansu = seans.ListaSeansow.Count + 1;
            foreach (film f in film.ListaFilmów)
            {
                if ((string)comboBox1.SelectedItem == f.Tytul)
                {
                    nowy_seans.F = f;
                }
            }
            foreach (Sala s in Sala.ListaSal)
            {
                if ((int)comboBox2.SelectedItem == s.Nrsali)
                {
                    nowy_seans.S = s;
                }
            }          
            if (seans.ListaSeansow.Count>0)
            {
                foreach (seans se in seans.ListaSeansow)
                {
                    if (se.Data_godz.Date == dateTimePicker1.Value.Date || se.S.Nrsali == (int)comboBox2.SelectedItem)
                    {
                        foreach (seans s in seans.ListaSeansow)
                        {

                            if (s.Data_godz.TimeOfDay.TotalMinutes + s.F.Dlugosctrwaniaseansu + 10 > dateTimePicker1.Value.TimeOfDay.TotalMinutes)
                            {
                                zamykanie = false;
                                MessageBox.Show("Nalezy tworzyć seanse w tej samej sali z 10 min przerwą");
                                comboBox2.SelectedIndex = -1;
                            }
                        }
                    }
                }
            }
            nowy_seans.Nrseansu = seans.ListaSeansow.Count + 1;
            nowy_seans.Data_godz = dateTimePicker1.Value;
            DialogResult = DialogResult.OK;
            if (zamykanie)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zamykanie = true;
            DialogResult = DialogResult.Cancel;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            Close();

        }

        private void new_seans_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!zamykanie)
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
                e.Cancel = true;
                return;
            }
        }

        private void new_seans_Load(object sender, EventArgs e)
        {
            foreach (film f in film.ListaFilmów)
            {
                comboBox1.Items.Add(f.Tytul);
            }
            foreach (Sala f in Sala.ListaSal)
            {
                comboBox2.Items.Add(f.Nrsali);
            }
            if(film.ListaFilmów.Count ==0)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (Sala f in Sala.ListaSal)
            {
                if (comboBox2.SelectedIndex == -1)
                {
                    label5.Text = "...";
                }
                else
                {
                    if (f.Nrsali == (int)comboBox2.SelectedItem)
                    {
                        label5.Text = f.Iloscmiejsce.ToString();
                    }
                }
            }
        }
    }
}
