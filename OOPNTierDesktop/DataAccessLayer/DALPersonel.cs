using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;//dal dan referans etik
using System.Data.SqlClient;//database bağlantısı gelmesi için 
using System.Data;

namespace DataAccessLayer// bu katman erişim ile buradaki verileri çağıracaz 
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()//statik olmasaydı database classından nene türetmem lazımdı sqlconnetion a erişmek için 
        {
            List<EntityPersonel> list=new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("select * from Personel", Database.sqlConnection);

            if (komut1.Connection.State !=ConnectionState.Open)//=ConnectionState.Closed diğer kullanım ,eğer bağlantı kapalıysa bağlantıyı aç anlamında
            {
                komut1.Connection.Open();
            }
            SqlDataReader oku= komut1.ExecuteReader();
            while(oku.Read())
            {
                EntityPersonel personel = new EntityPersonel();
                personel.Id = int.Parse(oku["ID"].ToString());
                personel.Adı = oku["Ad"].ToString();
                personel.Soyadı = oku["Soyad"].ToString();
                personel.Sehir = oku["Sehir"].ToString();
                personel.Gorev = oku["Gorev"].ToString();
                personel.Maas = short.Parse(oku["Maas"].ToString());
                list.Add(personel);
            }
            oku.Close();

            return list;
        }


        public static int PersonelEkle(EntityPersonel personel)
        {

            SqlCommand komut2 = new SqlCommand("insert into Personel(Ad,Soyad,Gorev,Sehir,Maas) values(@p1,@p2,@p3,@p4,@p5)", Database.sqlConnection);
            if (komut2.Connection.State == ConnectionState.Closed)
            {
                komut2.Connection.Open();
            }

            komut2.Parameters.AddWithValue("@p1",personel.Adı);
            komut2.Parameters.AddWithValue("@p2",personel.Soyadı);
            komut2.Parameters.AddWithValue("@p3",personel.Gorev);
            komut2.Parameters.AddWithValue("@p4",personel.Sehir);
            komut2.Parameters.AddWithValue("@p5",personel.Maas);
            return komut2.ExecuteNonQuery();
        }
        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("Delete from Personel where ıd=@p1", Database.sqlConnection);
            if (komut3.Connection.State == ConnectionState.Closed)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);
            return komut3.ExecuteNonQuery()>0;// bu algoritma bool yaptığımız için böyle yaptık 
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {

            SqlCommand komut4 = new SqlCommand("Update Personel set Ad=@p1,Soyad=@p2,Maas=@p3,Sehir=@p4,Gorev=@p5 where Id=@p6", Database.sqlConnection);
            if (komut4.Connection.State == ConnectionState.Closed)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", ent.Adı);
            komut4.Parameters.AddWithValue("@p2", ent.Soyadı);
            komut4.Parameters.AddWithValue("@p3", ent.Maas);
            komut4.Parameters.AddWithValue("@p4", ent.Sehir);
            komut4.Parameters.AddWithValue("@p5", ent.Gorev);
            komut4.Parameters.AddWithValue("@p6", ent.Id);
            return komut4.ExecuteNonQuery()>0;
        }
    }
}
