using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp18
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        Button btn = new Button();
        Label lblPuan = new Label();
        Timer timer = new Timer();
        int puan = 0;

        public Form1()
        {
            InitializeComponent();

            btn.Size = new Size(60, 60);
            btn.Click += Btn_Click;
            this.Controls.Add(btn);

            lblPuan.Text = "PUAN\n0";
            lblPuan.Location = new Point(this.ClientSize.Width - 100, 20);
            lblPuan.AutoSize = true;
            this.Controls.Add(lblPuan);

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int sayi = rnd.Next(1, 11);
            btn.Text = sayi.ToString();

            int x = rnd.Next(0, this.ClientSize.Width - btn.Width);
            int y = rnd.Next(0, this.ClientSize.Height - btn.Height);
            btn.Location = new Point(x, y);

            if (x < this.ClientSize.Width / 2)
            {
                btn.ForeColor = Color.Red; 
            }
            else
            {
                btn.ForeColor = Color.Black; 
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int sayi = int.Parse(btn.Text);

            if (btn.ForeColor == Color.Red)
            {
                puan += sayi;
            }
            else
            {
                puan -= sayi;
            }

            lblPuan.Text = $"PUAN\n{puan}";

            if (puan >= 100)
            {
                timer.Stop();
                MessageBox.Show("Oyun Bitti");
                btn.Enabled = false;
            }
        }
    }
}
