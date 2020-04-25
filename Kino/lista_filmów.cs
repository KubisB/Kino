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
    public partial class lista_filmów : Form
    {
        public lista_filmów()
        {
            InitializeComponent();
        }

        private void lista_filmów_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                film.ListaFilmów.Remove((film)r.Tag);

            refresh();
        }
        private void refresh()
        {
            dataGridView1.Rows.Clear();
            foreach (film p in film.ListaFilmów)
            {
                int nr_wiersza = dataGridView1.Rows.Add(new object[] { p.Nrfilmu, p.Tytul, p.Dlugosctrwaniaseansu.ToString() });
                dataGridView1.Rows[nr_wiersza].Tag = p;
            }
        }
    }
}
