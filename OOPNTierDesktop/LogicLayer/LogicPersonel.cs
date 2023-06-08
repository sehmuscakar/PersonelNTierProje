using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }

        public static int LLPersonelEkle(EntityPersonel p)
        {
            if (p.Adı!="" && p.Soyadı !="" &&p.Maas>350 && p.Adı.Length>=3)
            {
                return DALPersonel.PersonelEkle(p);
            }
            else
            {
                return -1;
            }
        }

        public static bool LLPersonelSil(int per)
        {
            if (per>=1)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }
        }

        public static bool LLPersonelGuncelle(EntityPersonel ent)
        {
            if (ent.Adı.Length>=3 && ent.Adı!="" && ent.Maas>=350)
            {
                return DALPersonel.PersonelGuncelle(ent);
            }
            else
            {
                return false;
            }
        }

    }
}
