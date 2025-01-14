using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Club
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void btn_uye_ekle_Click(object sender, EventArgs e)
        {
            Uye_Ekle uye_ekle = new Uye_Ekle();
            uye_ekle.Show();

            this.Hide();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            Guncelle_Sil guncelle_sil = new Guncelle_Sil();
            guncelle_sil.Show();

            this.Hide();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Uyeleri_Goruntule uyeleri_goruntulel = new Uyeleri_Goruntule();
            uyeleri_goruntulel.Show();

            this.Hide();
        }

        private void btn_odeme_Click(object sender, EventArgs e)
        {
            Analiz odeme = new Analiz();
            odeme.Show();

            this.Hide();
        }

        private void btn_anasayfa_geri_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paketler paketler = new Paketler();
            paketler.Show();
            this.Hide();
        }
    }
}
