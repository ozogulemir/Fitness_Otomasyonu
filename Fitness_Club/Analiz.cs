using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Fitness_Club
{
    public partial class Analiz : Form
    {
        public Analiz()
        {
            InitializeComponent();
        }

        private void Analiz_Load(object sender, EventArgs e)
        {
           
                try
                {
                    Baglanti.baglan.Open();

                    // SQL sorgusu: Uyelik sütunundan paketleri ve sayılarını çekiyoruz
                    string query = "SELECT Uyelik, COUNT(*) AS PaketSayisi FROM Uyeler GROUP BY Uyelik";
                    OleDbCommand command = new OleDbCommand(query, Baglanti.baglan);
                    OleDbDataReader reader = command.ExecuteReader();

                    // Paket adları ve sayılarını tutmak için listeler
                    List<string> paketAdlari = new List<string>();
                    List<int> paketSayilari = new List<int>();

                    while (reader.Read())
                    {
                        paketAdlari.Add(reader["Uyelik"].ToString());
                        paketSayilari.Add(Convert.ToInt32(reader["PaketSayisi"]));
                    }

                    // Grafiği çizdiriyoruz
                    CizGrafik(paketAdlari, paketSayilari);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı Hatası: " + ex.Message);
                }
            }
        
        private void CizGrafik(List<string> paketAdlari, List<int> paketSayilari)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            // Grafik başlığı ve eksen isimleri
            myPane.Title.Text = "Fitness Club Paket Dağılımı";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "Müşteri Sayısı";

            // Öncelikli sıralama: Bronz, Gümüş, Altın, Elmas
            string[] siraliPaketAdlari = { "Bronz Paket", "Gümüş Paket", "Altın Paket", "Elmas Paket" };
            int[] siraliPaketSayilari = new int[siraliPaketAdlari.Length];

            for (int i = 0; i < siraliPaketAdlari.Length; i++)
            {
                // Eğer sıralanmış paket listesinde varsa değerini atar, yoksa 0 koyar
                int index = paketAdlari.IndexOf(siraliPaketAdlari[i]);
                siraliPaketSayilari[i] = index >= 0 ? paketSayilari[index] : 0;
            }

            // Sütun renkleri (Bronz, Gümüş, Altın, Elmas)
        Color[] renkler = {
        Color.FromArgb(205, 127, 50), // Bronz rengi
        Color.Silver,                 // Gümüş rengi
        Color.Gold,                   // Altın rengi
        Color.FromArgb(85, 190, 255)  // Elmas rengi (mavi tonlu)
    };

          
            // Her paket için sütun ekle
            for (int i = 0; i < siraliPaketAdlari.Length; i++)
            {
                double[] yValues = { siraliPaketSayilari[i] }; // Tek bir değer için dizi
                double[] xValues = { i + 1 };                 // Sütun X koordinatı (etiket sırası ile aynı)

                // Sütun ekleme
                myPane.AddBar(siraliPaketAdlari[i], xValues, yValues, renkler[i]);
            }

            // Görsel düzenleme: Sütunların X ekseni etiketleri ile hizalanması
            myPane.XAxis.MajorTic.IsBetweenLabels = false; // Etiketlerin sütun altında olması
            myPane.BarSettings.Type = BarType.Cluster;    // Sütunları düzenli hizala
            //x eksenini boşaltmak için 
            myPane.XAxis.Scale.IsLabelsInside = false; // Etiketlerin eksen iç kısmında yer almamasını sağlar
            myPane.XAxis.Scale.IsVisible = false;     // X ekseni rakamlarını gizler

            // Y ekseni düzenleme (daha temiz görünüm)
            myPane.YAxis.Scale.Min = 0;

            // Grafiği güncelle
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            this.Close();
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
            Baglanti.baglan.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
    
}
