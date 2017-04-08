using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _1._2sayıbulma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomSayi randomuret = RandomSayi.NesneAl();
            randomuret.DegiskenAyarla(Convert.ToInt32(numericUpDown1.Value), radioButton1.Checked);
            List<int> uretilen = randomuret.Uret();

            TahminForm tahminet = new TahminForm(uretilen, Convert.ToInt32(numericUpDown2.Value));
            tahminet.Show();
            Hide();
        }
    }
}
