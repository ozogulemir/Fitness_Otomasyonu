using BusinessLayer;
using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fitness_Club
{
    public partial class Guncelle_Sil : Form
    {
        BLUye bLUye = new BLUye();
        private void UyeListele()
        {
            dgvUyeler.DataSource = bLUye.UyeListele();
        }
        public Guncelle_Sil()
        {
            InitializeComponent();
        }
        

        

        private void bt_uyeguncellesil_geri_Click(object sender, EventArgs e)
        {
            this.Close();
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        

            if (e.RowIndex >= 0) // Geçerli bir satır seçilmişse
            {
                DataGridViewRow row = dgvUyeler.Rows[e.RowIndex];

                // Null kontrolü yaparak değerleri al
                txtUyeAdiSoyadi.Text = row.Cells["UyeAdiSoyadi"].Value?.ToString() ?? string.Empty;
                txtTelefonNumarasi.Text = row.Cells["TelefonNumarasi"].Value?.ToString() ?? string.Empty;
                txtDogumTarihi.Text = row.Cells["DogumTarihi"].Value?.ToString() ?? string.Empty;
                cmbCinsiyet.Text = row.Cells["Cinsiyet"].Value.ToString() ?? string.Empty;
                txtMail.Text = row.Cells["Mail"].Value?.ToString() ??string.Empty;
                cmbUyelik.Text = row.Cells["Uyelik"].Value?.ToString() ?? string.Empty;
            }
        }

        private void bt_uyeguncellesil_guncelle_Click(object sender, EventArgs e)
        {
            


            if (dgvUyeler.SelectedRows.Count > 0) // Seçili bir satır var mı kontrolü
            {
                EntUye entUye = new EntUye
                {
                    Musteri_ID = dgvUyeler.SelectedRows[0].Cells["Musteri_ID"].Value.ToString(), // Seçilen satırdaki ID
                    UyeAdiSoyadi = txtUyeAdiSoyadi.Text,
                    TelefonNumarasi = txtTelefonNumarasi.Text,
                    DogumTarihi = txtDogumTarihi.Text,
                    Cinsiyet = cmbCinsiyet.Text,
                    Mail = txtMail.Text,
                    Uyelik = cmbUyelik.Text
                };

                bLUye.UyeGuncelle(entUye);
                MessageBox.Show("Üye başarıyla güncellendi.");
                UyeListele(); // Listeyi güncelle
            }
            else
            {
                MessageBox.Show("Güncellemek için bir üye seçmelisiniz.");
            }
        }



        private void bt_uyeguncellesil_sil_Click(object sender, EventArgs e)
        {
            string uyeAdiSoyadi = txtUyeAdiSoyadi.Text;
            bLUye.UyeSil(uyeAdiSoyadi);
            MessageBox.Show("Üye başarıyla silindi.");
            UyeListele(); // Listeyi güncelle
        }

        private void bt_uyeguncellesil_reset_Click(object sender, EventArgs e)
        {
            txtUyeAdiSoyadi.Clear();
            txtTelefonNumarasi.Clear();
            txtDogumTarihi.Clear();
            cmbCinsiyet.SelectedIndex = -1;
            txtMail.Clear();
            cmbUyelik.SelectedIndex = -1;

            UyeListele(); // Listeyi tekrar getir
        }
        private void DataGridViewAyarla()
        {
            dgvUyeler.Columns["UyeAdiSoyadi"].HeaderText = "Adı Soyadı";
            dgvUyeler.Columns["TelefonNumarasi"].HeaderText = "Telefon Numarası";
            dgvUyeler.Columns["DogumTarihi"].HeaderText = "Doğum Tarihi";
            dgvUyeler.Columns["Cinsiyet"].HeaderText = "Cinsiyet";
            dgvUyeler.Columns["Mail"].HeaderText = " Mail";
            dgvUyeler.Columns["Uyelik"].HeaderText = "Uyelik";
            // Gerekirse sütun genişliklerini ayarlayabiliriz
            dgvUyeler.Columns["UyeAdiSoyadi"].Width = 150;
            dgvUyeler.Columns["TelefonNumarasi"].Width = 100;
        }

        private void Guncelle_Sil_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde tüm üyeleri listele
            UyeListele();
            // DataGridView ayarlarını yap
            DataGridViewAyarla();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
