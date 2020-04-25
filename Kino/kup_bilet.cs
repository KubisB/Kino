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
    public partial class kup_bilet : Form
    {
        public kup_bilet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 ||
               comboBox2.SelectedIndex == -1 ||
               comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Proszę uzupełnić wsyzstkie pola");
            }

            
                string seans_c = comboBox1.SelectedItem.ToString();
                string[] seans_szczegoly = seans_c.Split(' ');
                foreach (seans s in seans.ListaSeansow)
                {
                    if (s.Nrseansu.ToString() == seans_szczegoly[0])
                    {
                        foreach (miejsce m in s.S.ListaMiejscWsali1)
                            if (m.Nrmiejsca == (int)comboBox2.SelectedItem)
                            {
                                m.Statusmiejsca = false;
                            }
                    }

                }
            MessageBox.Show("Dokonano zakupuy biletu. Dziękujemy!");
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (seans s in seans.ListaSeansow)
            {
                foreach (miejsce m in s.S.ListaMiejscWsali1)
                {
                    if (m.Statusmiejsca)
                    {
                        comboBox2.Items.Add(m.Nrmiejsca);
                    }
                }
            }
            foreach (seans s in seans.ListaSeansow)
            {
                if (s.S.Nrsali == Int32.Parse(comboBox1.SelectedItem.ToString()))
                {
                    comboBox3.Items.Add(s.Nrseansu.ToString() + " \"" + s.F.Tytul.ToString() + " \"" + s.Godzinarozpoczecia().ToString());
                }
            }
        }

        private void kup_bilet_Load(object sender, EventArgs e)
        {
            foreach (Sala s in Sala.ListaSal)
            {
                for (int i = 1; i <= Sala.ListaSal.Count; i++)
                {
                    comboBox1.Items.Add(s.Nrsali);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
