using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using System.Data.OleDb;


namespace BusinessLayer
{
    public class BLUye
    {
        public DALUyeler dalUye;
       

        public BLUye()
        {
            dalUye = new DALUyeler();
        }

      
        // Üye ekleme işlemi için iş kuralları
        public bool UyeEkle(EntUye uye)
        {
            // İş kuralları: Örneğin alanların boş olup olmadığını kontrol etme
            if (string.IsNullOrWhiteSpace(uye.UyeAdiSoyadi) || string.IsNullOrWhiteSpace(uye.TelefonNumarasi) ||
                uye.DogumTarihi == default || string.IsNullOrWhiteSpace(uye.Cinsiyet) ||
                string.IsNullOrWhiteSpace(uye.Uyelik) || string.IsNullOrWhiteSpace(uye.Mail))


            {
                throw new Exception("Lütfen tüm alanları doğru şekilde doldurun.");
            }

            // Eğer iş kuralları sağlanıyorsa veri ekleme işlemini çağır
            return dalUye.UyeEkle(uye);
        }
        public List<EntUye> UyeListele()
        {
            return dalUye.UyeListele();
        }
        public void UyeGuncelle(EntUye uye)
        {
            dalUye.UyeGuncelle(uye);
        }

        public void UyeSil(string uyeAdiSoyadi)
        {
            dalUye.UyeSil(uyeAdiSoyadi);
        }

    }


}
