using BusinessLayer;
using DataAccessLayer;
using EntityLayer;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Fitness_Club
{
    public partial class Uyeleri_Goruntule : Form
    {

        BLUye blUye = new BLUye();

        public Uyeleri_Goruntule()
        {
            InitializeComponent();
            ;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
        }


        private void UyeListele()
        {
            try
            {
                // Üyeleri listeleme işlemi
                List<EntUye> Uyeler = blUye.UyeListele();

                if (Uyeler != null && Uyeler.Count > 0)
                {
                    dgvUyeler.DataSource = Uyeler;
                }
                else
                {
                    MessageBox.Show("Veritabanında üye bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void DataGridViewAyarla()
        {
            dgvUyeler.Columns["Musteri_ID"].HeaderText = "Müşteri ID";
            dgvUyeler.Columns["UyeAdiSoyadi"].HeaderText = "Adı Soyadı";
            dgvUyeler.Columns["TelefonNumarasi"].HeaderText = "Telefon Numarası";
            dgvUyeler.Columns["DogumTarihi"].HeaderText = "Doğum Tarihi";
            dgvUyeler.Columns["Cinsiyet"].HeaderText = "Cinsiyet";
            dgvUyeler.Columns["Mail"].HeaderText = "Mail";
            dgvUyeler.Columns["Uyelik"].HeaderText = "Uyelik";
            // Gerekirse sütun genişliklerini ayarlayabiliriz
            dgvUyeler.Columns["UyeAdiSoyadi"].Width = 150;
            dgvUyeler.Columns["TelefonNumarasi"].Width = 100;
        }

        private void Uyeleri_Goruntule_Load_1(object sender, EventArgs e)
        {
            // Form yüklendiğinde tüm üyeleri listele
            UyeListele();
            // DataGridView ayarlarını yap
            DataGridViewAyarla();
        }



        private void btnArama_Click(object sender, EventArgs e)
        {
            // Arama kutusuna yazılan kelimeyi alıyoruz
            string aramaKelimesi = txtArama.Text;

            // Üye listesini yeniden çekiyoruz
            List<EntUye> uyelerListesi = blUye.UyeListele();

            // Arama kelimesine göre listeyi filtreliyoruz
            var filtrelenmisUyeler = uyelerListesi.Where(u => u.UyeAdiSoyadi.IndexOf(aramaKelimesi, StringComparison.OrdinalIgnoreCase) >= 0
                                                || u.TelefonNumarasi.IndexOf(aramaKelimesi, StringComparison.OrdinalIgnoreCase) >= 0
                                                || u.Cinsiyet.IndexOf(aramaKelimesi, StringComparison.OrdinalIgnoreCase) >= 0
                                                || u.Uyelik.IndexOf(aramaKelimesi, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


            // Filtrelenmiş üyeleri DataGridView'de gösteriyoruz
            dgvUyeler.DataSource = filtrelenmisUyeler;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {

            // 1. TextBox'ı temizle
            txtArama.Clear();

            // 2. Tüm üyeleri listele
            List<EntUye> uyeler = blUye.UyeListele(); // Business Layer'dan üyeleri al
            dgvUyeler.DataSource = uyeler; // DataGridView'e aktar
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {



            try
            {
                // PDF'nin kaydedileceği dosya yolu
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UyeListesi.pdf";

                // PDF belgesi oluştur
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));

                // PDF'yi aç
                pdfDoc.Open();

                // Font ayarlarını yap
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED); // Türkçe karakter desteği için
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK); // Yazı boyutu: 10

                // Başlık ekle
                Paragraph title = new Paragraph("Fitness Club Üyelik Bilgileri",
                    new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)); // Başlık fontu
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                pdfDoc.Add(title);

                // Tablo oluştur
                PdfPTable table = new PdfPTable(dgvUyeler.Columns.Count); // DataGridView sütun sayısına göre tablo oluştur
                table.WidthPercentage = 100;
                table.SpacingBefore = 10;

                // Sütun başlıklarını ekle
                foreach (DataGridViewColumn column in dgvUyeler.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font)); // Sütun başlıkları için font kullan
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY; // Başlık hücreleri için arka plan rengi
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                // Hücreleri ekle
                foreach (DataGridViewRow row in dgvUyeler.Rows)
                {
                    if (!row.IsNewRow) // Yeni satır değilse
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", font)); // Hücre için font
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER; // Yazı ortalanır
                            table.AddCell(pdfCell);
                        }
                    }
                }

                // Tabloyu PDF'e ekle
                pdfDoc.Add(table);

                // PDF'yi kapat
                pdfDoc.Close();

                MessageBox.Show("PDF başarıyla oluşturuldu: " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

    }

}




