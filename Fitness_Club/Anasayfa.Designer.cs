namespace Fitness_Club
{
    partial class Anasayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_anasayfa_geri = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_uye_ekle = new System.Windows.Forms.Button();
            this.btn_analiz = new System.Windows.Forms.Button();
            this.btn_guncelle_sil = new System.Windows.Forms.Button();
            this.btn_uye_goruntule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-72, -35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(926, 496);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 78);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btn_anasayfa_geri);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btn_uye_ekle);
            this.panel2.Controls.Add(this.btn_analiz);
            this.panel2.Controls.Add(this.btn_guncelle_sil);
            this.panel2.Controls.Add(this.btn_uye_goruntule);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 78);
            this.panel2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Crimson;
            this.button1.Location = new System.Drawing.Point(519, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 54);
            this.button1.TabIndex = 70;
            this.button1.Text = "Paketler";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_anasayfa_geri
            // 
            this.btn_anasayfa_geri.AutoSize = true;
            this.btn_anasayfa_geri.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_anasayfa_geri.ForeColor = System.Drawing.Color.Crimson;
            this.btn_anasayfa_geri.Location = new System.Drawing.Point(823, 9);
            this.btn_anasayfa_geri.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btn_anasayfa_geri.Name = "btn_anasayfa_geri";
            this.btn_anasayfa_geri.Size = new System.Drawing.Size(25, 28);
            this.btn_anasayfa_geri.TabIndex = 69;
            this.btn_anasayfa_geri.Text = "x";
            this.btn_anasayfa_geri.Click += new System.EventHandler(this.btn_anasayfa_geri_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 78);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // btn_uye_ekle
            // 
            this.btn_uye_ekle.BackColor = System.Drawing.Color.DarkGray;
            this.btn_uye_ekle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_uye_ekle.ForeColor = System.Drawing.Color.Crimson;
            this.btn_uye_ekle.Location = new System.Drawing.Point(106, 12);
            this.btn_uye_ekle.Name = "btn_uye_ekle";
            this.btn_uye_ekle.Size = new System.Drawing.Size(133, 54);
            this.btn_uye_ekle.TabIndex = 1;
            this.btn_uye_ekle.Text = "Üye Ekle";
            this.btn_uye_ekle.UseVisualStyleBackColor = false;
            this.btn_uye_ekle.Click += new System.EventHandler(this.btn_uye_ekle_Click);
            // 
            // btn_analiz
            // 
            this.btn_analiz.BackColor = System.Drawing.Color.DarkGray;
            this.btn_analiz.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_analiz.ForeColor = System.Drawing.Color.Crimson;
            this.btn_analiz.Location = new System.Drawing.Point(658, 12);
            this.btn_analiz.Name = "btn_analiz";
            this.btn_analiz.Size = new System.Drawing.Size(133, 54);
            this.btn_analiz.TabIndex = 4;
            this.btn_analiz.Text = "Analiz";
            this.btn_analiz.UseVisualStyleBackColor = false;
            this.btn_analiz.Click += new System.EventHandler(this.btn_odeme_Click);
            // 
            // btn_guncelle_sil
            // 
            this.btn_guncelle_sil.BackColor = System.Drawing.Color.DarkGray;
            this.btn_guncelle_sil.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_guncelle_sil.ForeColor = System.Drawing.Color.Crimson;
            this.btn_guncelle_sil.Location = new System.Drawing.Point(380, 12);
            this.btn_guncelle_sil.Name = "btn_guncelle_sil";
            this.btn_guncelle_sil.Size = new System.Drawing.Size(133, 54);
            this.btn_guncelle_sil.TabIndex = 5;
            this.btn_guncelle_sil.Text = "Güncelle/Sil";
            this.btn_guncelle_sil.UseVisualStyleBackColor = false;
            this.btn_guncelle_sil.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_uye_goruntule
            // 
            this.btn_uye_goruntule.BackColor = System.Drawing.Color.DarkGray;
            this.btn_uye_goruntule.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_uye_goruntule.ForeColor = System.Drawing.Color.Crimson;
            this.btn_uye_goruntule.Location = new System.Drawing.Point(245, 12);
            this.btn_uye_goruntule.Name = "btn_uye_goruntule";
            this.btn_uye_goruntule.Size = new System.Drawing.Size(129, 54);
            this.btn_uye_goruntule.TabIndex = 2;
            this.btn_uye_goruntule.Text = "Üye Görüntüle";
            this.btn_uye_goruntule.UseVisualStyleBackColor = false;
            this.btn_uye_goruntule.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Anasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_uye_ekle;
        private System.Windows.Forms.Button btn_analiz;
        private System.Windows.Forms.Button btn_guncelle_sil;
        private System.Windows.Forms.Button btn_uye_goruntule;
        private System.Windows.Forms.Label btn_anasayfa_geri;
        private System.Windows.Forms.Button button1;
    }
}