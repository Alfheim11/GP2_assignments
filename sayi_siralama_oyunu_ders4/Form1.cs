namespace sayısecmeoyunu_ders4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Button> oyunButonlari = new List<Button>();
        List<int> ciftSayilar = new List<int>();
        int siradakiCiftIndex = 0;
        int kalanSure = 60;
        Random rastgele = new Random();
        Random rnd = new Random();

        private void btnBasla_Click(object sender, EventArgs e)
        {
            OyunHazirla();
            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(40, 30);
                btn.Font = new Font("Arial", 12, FontStyle.Bold);

                int sayi = rastgele.Next(1, 101);
                btn.Text = sayi.ToString();

                if (sayi % 2 == 0)
                {
                    ciftSayilar.Add(sayi);
                }

                int x = rastgele.Next(10, gbOyunAlani.Width - btn.Width - 10);
                int y = rastgele.Next(20, gbOyunAlani.Height - btn.Height - 10);
                btn.Location = new Point(x, y);

                btn.Click += OyunButonu_Click;
                oyunButonlari.Add(btn);
                gbOyunAlani.Controls.Add(btn);
            }

            ciftSayilar.Sort();

            sureTimer.Start();
        }

        private void OyunButonu_Click(object sender, EventArgs e)
        {
            Button tiklananButon = (Button)sender;
            int sayi = int.Parse(tiklananButon.Text);

            if (sayi % 2 != 0)
            {
                OyunBitti(false, "Yanlış! Tek sayıya tıkladın. Kaybettin!");
                return;
            }

            if (ciftSayilar.Count == 0 || siradakiCiftIndex >= ciftSayilar.Count)
            {
                OyunBitti(false, "Hatalı işlem! Kaybettin!");
                return;
            }

            if (sayi == ciftSayilar[siradakiCiftIndex])
            {
                tiklananButon.Visible = false;
                lstSecilenler.Items.Add(sayi);
                siradakiCiftIndex++;
            }
            else
            {
                OyunBitti(false, "Yanlış sıra! Çift sayıları küçükten büyüğe seçmelisin. Kaybettin!");
                return;
            }

            if (siradakiCiftIndex == ciftSayilar.Count)
            {
                btnBitir.Enabled = true;
            }

        }

        void OyunHazirla()
        {
            kalanSure = 60;
            lblSure.Text = "SÜRE\n60 sn";
            siradakiCiftIndex = 0;

            ciftSayilar.Clear();
            lstSecilenler.Items.Clear();
            gbOyunAlani.Controls.Clear();
            oyunButonlari.Clear();

            btnBasla.Enabled = false;
            btnBitir.Enabled = false;
        }

        void OyunBitti(bool kazandiMi, string mesaj)
        {
            sureTimer.Stop();
            gbOyunAlani.Enabled = false;

            MessageBox.Show(mesaj, "Oyun Sonu");

            gbOyunAlani.Enabled = true;
            gbOyunAlani.Controls.Clear();
            lstSecilenler.Items.Clear();
            btnBasla.Enabled = true;
            btnBitir.Enabled = false;
            lblSure.Text = "SÜRE";
        }
        private void btnBitir_Click(object sender, EventArgs e)
        {
            sureTimer.Stop();
            OyunBitti(true, $"{kalanSure} saniye kala oyunu doğru bitirdin!");

        }

        private void sureTimer_Tick(object sender, EventArgs e)
        {


            foreach (var btn in oyunButonlari)
            {
                int x = rnd.Next(10, gbOyunAlani.Width - btn.Width - 10);
                int y = rnd.Next(20, gbOyunAlani.Height - btn.Height - 10);
                btn.Location = new Point(x, y);
            }

            sureTimer.Interval = 1000;
            kalanSure--;
            lblSure.Text = "SÜRE\n" + kalanSure + " sn";

            if (kalanSure <= 0)
            {
                OyunBitti(false, "Süre Bitti! Kaybettin!");
            }
        }
    }
}
