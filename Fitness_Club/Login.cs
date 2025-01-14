using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using System.Data.OleDb;



namespace Fitness_Club
{
    public partial class Login : Form
    {
        BLPersonel personelBL = new BLPersonel();
        public Login()
        {
            InitializeComponent();
        }
      
        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            bool girisBasarili = personelBL.GirisYap(kullaniciAdi, sifre);

            if (girisBasarili)
            {
                MessageBox.Show("Giriş başarılı!");

                // Ana sayfa formunu oluştur ve göster
                Anasayfa anaSayfa = new Anasayfa();
                anaSayfa.Show();

                // Bu formu kapatabilirsiniz veya gizleyebilirsiniz
                this.Hide(); // Formu gizlemek isterseniz
                // Ana ekrana yönlendirme yapılabilir.
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // TextBox'ların içeriğini temizle
            txtKullaniciAdi.Text = "";  // Kullanıcı adı TextBox'ını temizler
            txtSifre.Text = "";         // Şifre TextBox'ını temizler
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
