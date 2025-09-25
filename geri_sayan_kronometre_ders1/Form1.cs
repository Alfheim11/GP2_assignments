using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gorselprog2ders1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool esitlendi = false;
        bool gerisayim = false;

        int salise = 0;
        int saniye = DateTime.Now.Second - 5;
        int dakika = DateTime.Now.Minute;
        int saat = DateTime.Now.Hour;


        int sistemsaat = DateTime.Now.Hour;
        int sistemdakika = DateTime.Now.Minute;
        int sistemsaniye = DateTime.Now.Second;
        private void button1_Click(object sender, EventArgs e)
        {
            if (esitlendi == false && gerisayim == false)
            {
                label1.Text = saat.ToString();
                label2.Text = dakika.ToString();
                label3.Text = saniye.ToString();
                label4.Text = salise.ToString();
                timer1.Interval = 10;
                timer1.Start();
                btnBasla.Enabled = false;
            }
            if (esitlendi == true && gerisayim == false)
            {
                gerisayim = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (esitlendi == true && gerisayim == false)
            {
                btnBasla.BackColor = Color.Green;
                salise++;
                if (salise == 100)
                {
                    saniye++;
                    salise = 0;
                }

                if (saniye == 60)
                {
                    dakika++;
                    saniye = 0;
                }

                if (dakika == 60)
                {
                    saat++;
                    dakika = 0;
                }
                label1.Text = saat.ToString();
                label2.Text = dakika.ToString();
                label3.Text = saniye.ToString();
                label4.Text = salise.ToString();
            }
            if (esitlendi == false && gerisayim == false)
            {
                salise++;
                if (salise == 100)
                {
                    saniye++;
                    salise = 0;
                }

                if (saniye == 60)
                {
                    dakika++;
                    saniye = 0;
                }

                if (dakika == 60)
                {
                    saat++;
                    dakika = 0;
                }
                label1.Text = saat.ToString();
                label2.Text = dakika.ToString();
                label3.Text = saniye.ToString();
                label4.Text = salise.ToString();
            }

            if (esitlendi == true && gerisayim == true)
            {
                btnBasla.Enabled = true;
                btnBasla.BackColor = Color.Green;

                label5.Text = saat.ToString();
                label6.Text = dakika.ToString();
                label7.Text = saniye.ToString();
                label8.Text = salise.ToString();

                if (salise == 0)
                {
                    salise = 100;
                    saniye--;
                }

                salise--;

                if (saniye == 0)
                {
                    dakika--;
                    saniye = 60;
                }

                if (dakika == 00)
                {
                    saat--;
                    dakika = 60;
                }
            }
            if (saat == sistemsaat && dakika == sistemdakika && saniye == sistemsaniye && esitlendi == false)
            {
                esitlendi = true;
                btnBasla.Enabled = true;
            }

        }

    }
}
