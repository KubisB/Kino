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
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                zamykanie = false;
            }
            else
            {
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
            nowy_seans.Nrseansu = seans.ListaSeansow.Count + 1;
            nowy_seans.Data_godz = dateTimePicker1.Value;
            DialogResult = DialogResult.OK;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
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
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (Sala f in Sala.ListaSal)
            {
                if (f.Nrsali == (int)comboBox2.SelectedItem)
                    label5.Text = f.Iloscmiejsce.ToString();
            }
        }
    }
}
