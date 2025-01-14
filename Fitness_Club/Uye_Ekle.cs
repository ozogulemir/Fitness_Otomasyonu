using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using System.Net.Mail;
using System.Net;
namespace Fitness_Club
{
    public partial class Uye_Ekle : Form
    {
        private BLUye blUye;

        public Uye_Ekle()
        {
            InitializeComponent();
            blUye = new BLUye();
        }

        private void btn_Reset_uyeekle_Click(object sender, EventArgs e)
        {
            // TextBox'ların içeriğini temizle
            txt_Ad_Soyad.Text = "";  
            txt_Mail.Text = "";
            txt_Dogum_Tarihi.Text = "";
            txt_Tel_No.Text = "";
            cmbbx_Uyelik.Text = "";
            Cmbbx_Cinsiyet.Text = "";
        }

        private void btn_uyeekle_geri_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ilerle_Click(object sender, EventArgs e)
        {// Paneli görünür hale getir
         // Paneli görünür hale getir
            panel2.Visible = false;
            panel1.Visible = true;




            // Üye bilgilerini Ödeme groupbox'ına taşı ve değiştirilemez yap
            txtUyeAdiSoyadiOdeme.Text = txt_Ad_Soyad.Text;
            txtUyeAdiSoyadiOdeme.ReadOnly = true;

            txtTelefonNumarasiOdeme.Text = txt_Tel_No.Text;
            txtTelefonNumarasiOdeme.ReadOnly = true;

            txtDogumTarihiOdeme.Text = txt_Dogum_Tarihi.Text;
            txtDogumTarihiOdeme.ReadOnly = true;

            txtCinsiyetOdemede.Text = Cmbbx_Cinsiyet.Text;
            txtCinsiyetOdemede.ReadOnly = true;

            txtMailOdeme.Text = txt_Mail.Text;
            txtMailOdeme.ReadOnly = true;

            txtUyelikOdemede.Text = cmbbx_Uyelik.Text;
            txtUyelikOdemede.ReadOnly = true;
        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Entity sınıfına kullanıcıdan gelen verileri atama
                EntUye yeniUye = new EntUye
                {
                    UyeAdiSoyadi = txt_Ad_Soyad.Text,
                    TelefonNumarasi = txt_Tel_No.Text,
                    DogumTarihi = txt_Dogum_Tarihi.Text,
                    Cinsiyet = Cmbbx_Cinsiyet.SelectedItem?.ToString(),
                    Mail = txt_Mail.Text,
                    Uyelik = cmbbx_Uyelik.SelectedItem?.ToString()
                };

                // Üye ekleme işlemi
                bool eklendiMi = blUye.UyeEkle(yeniUye);

                if (eklendiMi)
                {
                    MessageBox.Show("Üye başarıyla eklendi.");

                    // E-posta gönderim işlemi
                    try
                    {
                        string subject = "Fitness Club Üyelik Bilgileriniz";
                        string body = $"Merhaba {yeniUye.UyeAdiSoyadi},\n\n" +
                                      $"Telefon Numaranız: {yeniUye.TelefonNumarasi}\n" +
                                      $"Doğum Tarihiniz: {yeniUye.DogumTarihi}\n" +
                                      $"Cinsiyet: {yeniUye.Cinsiyet}\n" +
                                      $"Üyelik Türü: {yeniUye.Uyelik}\n\n" +
                                      $"Fitness Club'a katıldığınız için teşekkür ederiz!";

                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("ozogulemir@gmail.com"); // Gönderen adres
                        mail.To.Add(yeniUye.Mail); // Kullanıcının mail adresi
                        mail.Subject = subject;
                        mail.Body = body;

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // SMTP sunucusu
                        smtpClient.Port = 587; // Genelde kullanılan SMTP portu
                        smtpClient.Credentials = new NetworkCredential("fitnessclubduzce@gmail.com", "kbkr oqtw tcif txzx"); // Giriş bilgileri
                        smtpClient.EnableSsl = true; // Güvenli bağlantı için SSL aktif

                        smtpClient.Send(mail); // E-posta gönderimi
                        MessageBox.Show("Üyeye e-posta gönderildi.");
                    }
                    catch (Exception emailEx)
                    {
                        MessageBox.Show("E-posta gönderilirken bir hata oluştu: " + emailEx.Message);
                    }

                    // Formu temizle
                    txt_Ad_Soyad.Clear();
                    txt_Tel_No.Clear();
                    txt_Mail.Clear();
                    Cmbbx_Cinsiyet.SelectedIndex = -1;
                    cmbbx_Uyelik.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Üye eklenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
            Uye_Ekle uye_Ekle = new Uye_Ekle();
            uye_Ekle.Show();
       
        }

        private void btn_uye_ekle_geri_Click(object sender, EventArgs e)
        {
            this.Close();
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
        }

     
    }
 }
 

