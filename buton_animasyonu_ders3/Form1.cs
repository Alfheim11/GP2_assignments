using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace movingbutton_ders3
{
    public partial class Form1 : Form
    {

        private class ButtonData
        {
            public Button Button { get; set; }
            public Point TargetCorner { get; set; }
            public Point StartCenter { get; set; }
        }

        private readonly List<ButtonData> buttonList = new List<ButtonData>();
        private const int ButtonSize = 75;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            this.Text = "Buton Kayma Animasyonu";
            this.DoubleBuffered = true;

            CreateAndPositionButtons();
            StartAnimationTask();
        }

        private void CreateAndPositionButtons()
        {   
            Point formCenter = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
   
            Point centerStart = new Point(formCenter.X - ButtonSize / 2, formCenter.Y - ButtonSize / 2);

            Point[] targetCorners = new Point[]
            {
            new Point(10, 10),
            new Point(this.ClientSize.Width - ButtonSize - 10, 10), 
            new Point(10, this.ClientSize.Height - ButtonSize - 10), 
            new Point(this.ClientSize.Width - ButtonSize - 10, this.ClientSize.Height - ButtonSize - 10) 
            };

            for (int i = 0; i < 4; i++)
            {
                Button btn = new Button
                {
                    Text = $"Buton {i + 1}",
                    Size = new Size(ButtonSize, ButtonSize),
                    Location = centerStart 
                };
                this.Controls.Add(btn);

                buttonList.Add(new ButtonData
                {
                    Button = btn,
                    TargetCorner = targetCorners[i],
                    StartCenter = centerStart
                });
            }
        }

        private void Form1_SizeChanged(object? sender, EventArgs e)
        {
            Point formCenter = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            Point centerStart = new Point(formCenter.X - ButtonSize / 2, formCenter.Y - ButtonSize / 2);

          
            buttonList[0].TargetCorner = new Point(10, 10);
            buttonList[1].TargetCorner = new Point(this.ClientSize.Width - ButtonSize - 10, 10); 
            buttonList[2].TargetCorner = new Point(10, this.ClientSize.Height - ButtonSize - 10); 
            buttonList[3].TargetCorner = new Point(this.ClientSize.Width - ButtonSize - 10, this.ClientSize.Height - ButtonSize - 10);


            foreach (var data in buttonList)
            {
                data.StartCenter = centerStart;
            }
        }
             private bool shouldAnimate = true;

        private void StartAnimationTask()
        {

            Task.Run(async () =>
            {
                float speed = 0.05f;
                float t = 0;
                bool movingToCorner = true;

               
                while (shouldAnimate)
                {
                    
                    t += speed;

                    
                    if (t > 1.0f)
                    {
                        t = 0;
                        movingToCorner = !movingToCorner;
                    }


                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateButtonPositions(t, movingToCorner);
                    });


                    await Task.Delay(16);
                }
            });
            this.FormClosing += (sender, e) => { shouldAnimate = false; };
        }
        private void UpdateButtonPositions(float t, bool toCorner)
        {

            foreach (var data in buttonList)
            {
                Point startPoint, endPoint;

                if (toCorner)
                {
                    startPoint = data.StartCenter;
                    endPoint = data.TargetCorner;
                }
                else
                {
                    startPoint = data.TargetCorner;
                    endPoint = data.StartCenter;
                }
                int newX = (int)(startPoint.X + (endPoint.X - startPoint.X) * t);
                int newY = (int)(startPoint.Y + (endPoint.Y - startPoint.Y) * t);

                data.Button.Location = new Point(newX, newY);
            }
        }
    }
}
    
