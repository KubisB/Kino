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
    public partial class new_film : Form
    {
        private film nowy_film;
        bool zamykanie;
        public new_film(film nowy_film)
        {
            InitializeComponent();
            this.nowy_film = nowy_film;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                zamykanie = false;
            }
            else
            {
                zamykanie = true;
            }
            nowy_film.Nrfilmu = film.ListaFilmów.Count + 1;
            nowy_film.Tytul = textBox1.Text;
            nowy_film.Dlugosctrwaniaseansu = (double)numericUpDown1.Value;
            DialogResult = DialogResult.OK;

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zamykanie = true;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void new_film_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (!zamykanie)
                {
                    MessageBox.Show("Proszę uzupełnić wszystkie pola");
                    e.Cancel = true;
                    return;
                }
          
        }
    }
}
