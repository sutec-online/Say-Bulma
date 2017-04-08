using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _1._2sayıbulma
{
    public partial class TahminForm : Form
    {
        List<int> sayi;
        int hak;
        int sayac = 0;

        public TahminForm(List<int> sayi, int hak)
        {
            InitializeComponent();
            this.sayi = sayi;
            this.hak = hak;
        }

        private void TahminForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sayi.Count; i++)
            {
                var tb = Controls[1].Controls["textBox" + (i+1)];
                tb.Visible = true;

                var lb = Controls[1].Controls["label" + (i + 2)];
                lb.Visible = true;
            }

            label11.Text = hak.ToString();
            timer1.Start();
        }

        private void TextBoxKontrol(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string textbox = tb.Name.Split('x')[2];
            int tbkod = (Convert.ToInt32(textbox)) - 1;

            if (sayi[tbkod] == Convert.ToInt32(tb.Text))
            {
                var lb = Controls[1].Controls["label" + (tbkod + 2)];
                lb.BackColor = Color.Blue;
                sayac++;
            }
            else
            {
                for (int i = 0; i < sayi.Count; i++)
                {
                    if (sayi[i] == Convert.ToInt32(tb.Text))
                    {
                        var lb = Controls[1].Controls["label" + (tbkod + 2)];
                        lb.BackColor = Color.Red;
                        break;
                    }
                    else
                    {
                        if ((sayi.Count - 1) == i)
                        {
                            var lb = Controls[1].Controls["label" + (tbkod + 2)];
                            lb.BackColor = Color.White;
                            break;
                        }
                    }
                }

                hak--;
                label11.Text = hak.ToString();
            }

            OyunSonuc();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hak--;
            label11.Text = hak.ToString();
            OyunSonuc();
        }

        private void OyunSonuc()
        {
            if (sayac == sayi.Count)
            {
                MessageBox.Show("TEBRİKLER!");
                SkorYazici(100);
                Application.Exit();
            }

            if (hak == 0)
            {
                MessageBox.Show("HAKKINIZ DOLDU!");
                SkorYazici(sayac * 5);
                Application.Exit();
            }
        }

        private void SkorYazici(int skor)
        {
            SkorYonetimi skoryonet = new SkorYonetimi("C:/1.2sayibulma/skor.txt");
            skoryonet.SkorYaz(skor);
        }
    }
}
