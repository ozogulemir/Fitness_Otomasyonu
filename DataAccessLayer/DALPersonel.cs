using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;



namespace DataAccessLayer
{
    public class DALPersonel
    {
       
        // Personel Giriş Kontrolü
        public bool PersonelGirisYap(string kullaniciAdi, string sifre)
        {

               
                string query = "SELECT COUNT(*) FROM Personel_Giris WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                OleDbCommand cmd = new OleDbCommand(query, Baglanti.baglan);
                cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@Sifre", sifre);

                Baglanti.baglan.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            
        }
    }
}
