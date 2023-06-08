using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityPersonel
    {
        //sql tnımalanan smallint burda short olarak tanımlanır.
        public int Id { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string Sehir { get; set; }
        public string Gorev { get; set; }
        public short Maas { get; set; }





    }
}
