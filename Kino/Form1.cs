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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sala Sala_1 = new Sala();
            Sala_1.Nrsali = 1;
            Sala_1.Iloscrzedow = 10;
            Sala_1.Iloscmiejsce = 50;
            Sala_1.Obraz = "2D";
            Sala_1.Miejsca();
            Sala.ListaSal.Add(Sala_1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(seans s in seans.ListaSeansow)
            MessageBox.Show(s.S.Obraz);
            refresh();
        }
        private void refresh()
        {
            dataGridView1.Rows.Clear();
            int lp = 1;
            foreach (seans p in seans.ListaSeansow)
            {
                int nr_wiersza = dataGridView1.Rows.Add(new object[] {p.Nrseansu, p.F.Tytul, p.Data(), p.Godzinarozpoczecia(), p.S.Nrsali, p.F.Dlugosctrwaniaseansu + " min" });
                lp++;
                dataGridView1.Rows[nr_wiersza].Tag = p;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            film p = new film();
            new_film f = new new_film(p);
            if (f.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            film.ListaFilmów.Add(p);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lista_filmów f = new lista_filmów();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            seans p = new seans();
            new_seans s = new new_seans(p);
            if (s.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            seans.ListaSeansow.Add(p);
 
            refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rezerwacja p = new rezerwacja();
            add_reservation res = new add_reservation(p);
            if(res.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
        }
    }
}
