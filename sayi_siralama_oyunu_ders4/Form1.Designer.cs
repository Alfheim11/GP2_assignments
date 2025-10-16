namespace sayısecmeoyunu_ders4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnBasla = new Button();
            gbOyunAlani = new GroupBox();
            lstSecilenler = new ListBox();
            btnBitir = new Button();
            lblSure = new Label();
            sureTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnBasla
            // 
            btnBasla.BackColor = Color.Firebrick;
            btnBasla.Location = new Point(23, 88);
            btnBasla.Name = "btnBasla";
            btnBasla.Size = new Size(132, 88);
            btnBasla.TabIndex = 0;
            btnBasla.Text = "OYUNA BAŞLA";
            btnBasla.UseVisualStyleBackColor = false;
            btnBasla.Click += btnBasla_Click;
            // 
            // gbOyunAlani
            // 
            gbOyunAlani.BackColor = Color.WhiteSmoke;
            gbOyunAlani.Location = new Point(178, 12);
            gbOyunAlani.Name = "gbOyunAlani";
            gbOyunAlani.Size = new Size(428, 440);
            gbOyunAlani.TabIndex = 1;
            gbOyunAlani.TabStop = false;
            gbOyunAlani.Text = "Oyun Alanı";
            // 
            // lstSecilenler
            // 
            lstSecilenler.BackColor = Color.MistyRose;
            lstSecilenler.FormattingEnabled = true;
            lstSecilenler.Location = new Point(612, 88);
            lstSecilenler.Name = "lstSecilenler";
            lstSecilenler.Size = new Size(150, 364);
            lstSecilenler.TabIndex = 2;
            // 
            // btnBitir
            // 
            btnBitir.BackColor = Color.Firebrick;
            btnBitir.Location = new Point(23, 280);
            btnBitir.Name = "btnBitir";
            btnBitir.Size = new Size(132, 88);
            btnBitir.TabIndex = 3;
            btnBitir.Text = "OYUNU BİTİR";
            btnBitir.UseVisualStyleBackColor = false;
            btnBitir.Click += btnBitir_Click;
            // 
            // lblSure
            // 
            lblSure.AutoSize = true;
            lblSure.Location = new Point(669, 12);
            lblSure.Name = "lblSure";
            lblSure.Size = new Size(44, 20);
            lblSure.TabIndex = 4;
            lblSure.Text = "SÜRE";
            // 
            // sureTimer
            // 
            sureTimer.Tick += sureTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCoral;
            ClientSize = new Size(776, 462);
            Controls.Add(lblSure);
            Controls.Add(btnBitir);
            Controls.Add(lstSecilenler);
            Controls.Add(gbOyunAlani);
            Controls.Add(btnBasla);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBasla;
        private GroupBox gbOyunAlani;
        private ListBox lstSecilenler;
        private Button btnBitir;
        private Label lblSure;
        private System.Windows.Forms.Timer sureTimer;
    }
}
