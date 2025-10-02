namespace butonkaydirma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool kaydirma = false;
        Point ilknokta;

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            kaydirma = true;
            ilknokta = e.Location;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if(kaydirma)
            {
                button1.Left = e.X + button1.Left - ilknokta.X;
                button1.Top = e.Y + button1.Top - ilknokta.Y;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            kaydirma = false;
        }
    }
}
