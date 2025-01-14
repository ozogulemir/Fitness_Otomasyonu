using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using DataAccessLayer;


namespace BusinessLayer
{
    public class BLPersonel
    {
        DALPersonel personelDAL = new DALPersonel();

        // Giriş Kontrolü
        public bool GirisYap(string kullaniciAdi, string sifre)
        {
            // İş kuralları buraya eklenebilir. Örneğin, şifre karma işlemi gibi.
            return personelDAL.PersonelGirisYap(kullaniciAdi, sifre);
        }
    }
}
