using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using EntityLayer;



namespace DataAccessLayer
{
    public class DALUyeler
    {
       
        // Üye ekleme metodu
        public bool UyeEkle(EntUye uye)
        {
           
            try
            {
                Baglanti.baglan.Open();
                //sorgu
                string sorgu = "INSERT INTO Uyeler (UyeAdiSoyadi, TelefonNumarasi, DogumTarihi, Cinsiyet, Mail, Uyelik) " +
                               "VALUES (@UyeAdiSoyadi, @TelefonNumarasi, @DogumTarihi, @Cinsiyet, @Mail, @Uyelik)";

                OleDbCommand komut = new OleDbCommand(sorgu, Baglanti.baglan);
                komut.Parameters.AddWithValue("@UyeAdiSoyadi", uye.UyeAdiSoyadi);
                komut.Parameters.AddWithValue("@TelefonNumarasi", uye.TelefonNumarasi);
                komut.Parameters.AddWithValue("@DogumTarihi", uye.DogumTarihi);
                komut.Parameters.AddWithValue("@Cinsiyet", uye.Cinsiyet);
                komut.Parameters.AddWithValue("@Mail", uye.Mail);
                komut.Parameters.AddWithValue("@Uyelik", uye.Uyelik);

               
                int result = komut.ExecuteNonQuery();
                return result > 0; // Etkilenen satır sayısı kontrolü
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanına ekleme sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                Baglanti.baglan.Close();
            }
        }
        public List<EntUye> UyeListele()
        {
            List<EntUye> uyelerListesi = new List<EntUye>();
            string sorgu = "SELECT * FROM Uyeler ORDER BY Musteri_ID ASC"; // Sıralama eklendi

            try
            {
                if (Baglanti.baglan.State == ConnectionState.Closed)
                {
                    Baglanti.baglan.Open();
                }

                using (OleDbCommand komut = new OleDbCommand(sorgu, Baglanti.baglan))
                {
                    using (OleDbDataReader okuyucu = komut.ExecuteReader())
                    {
                        while (okuyucu.Read())
                        {
                            EntUye uye = new EntUye
                            {
                                Musteri_ID = okuyucu["Musteri_ID"].ToString(),
                                UyeAdiSoyadi = okuyucu["UyeAdiSoyadi"].ToString(),
                                TelefonNumarasi = okuyucu["TelefonNumarasi"].ToString(),
                                DogumTarihi = okuyucu["DogumTarihi"].ToString(),
                                Cinsiyet = okuyucu["Cinsiyet"].ToString(),
                                Mail = okuyucu["Mail"].ToString(),
                                Uyelik = okuyucu["Uyelik"].ToString()
                            };
                            uyelerListesi.Add(uye);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Üyeleri listeleme sırasında bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (Baglanti.baglan.State == ConnectionState.Open)
                {
                    Baglanti.baglan.Close();
                }
            }

            return uyelerListesi;
        }
        public void UyeGuncelle(EntUye uye)
        {
            //sorgu
            OleDbCommand cmd2 = new OleDbCommand("UPDATE Uyeler SET  UyeAdiSoyadi= @UyeAdiSoyadi, TelefonNumarasi= @TelefonNumarasi, DogumTarihi= @DogumTarihi, " +
                "Cinsiyet= @Cinsiyet, Mail= @Mail, Uyelik= @Uyelik WHERE  Musteri_ID= @p1",Baglanti.baglan);

           
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }

                cmd2.Parameters.AddWithValue("@UyeAdiSoyadi", uye.UyeAdiSoyadi);
                cmd2.Parameters.AddWithValue("@TelefonNumarasi", uye.TelefonNumarasi);
                cmd2.Parameters.AddWithValue("@DogumTarihi", uye.DogumTarihi);
                cmd2.Parameters.AddWithValue("@Cinsiyet", uye.Cinsiyet);
                cmd2.Parameters.AddWithValue("@Mail", uye.Mail);
                cmd2.Parameters.AddWithValue("@Uyelik", uye.Uyelik);
                cmd2.Parameters.AddWithValue("@p1", uye.Musteri_ID);
                cmd2.ExecuteNonQuery();
                Baglanti.baglan.Close();

        }


        // Üye silme
        public void UyeSil(string uyeAdiSoyadi)
        {

            string query = "DELETE FROM Uyeler WHERE UyeAdiSoyadi = @UyeAdiSoyadi";

            try
            {
                if (Baglanti.baglan.State == ConnectionState.Closed)
                {
                    Baglanti.baglan.Open();
                }

                OleDbCommand command = new OleDbCommand(query, Baglanti.baglan);
                command.Parameters.AddWithValue("@UyeAdiSoyadi", uyeAdiSoyadi.Trim()); // Fazladan boşluklar kaldırıldı.

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Kayıt başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Silme işlemi başarısız. Kayıt bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                if (Baglanti.baglan.State == ConnectionState.Open)
                {
                    Baglanti.baglan.Close();
                }
            }
        }
            

    }
 }
