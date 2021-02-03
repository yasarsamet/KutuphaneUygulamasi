using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OduncAl:IEntity
    {
        public int id{ get; set; }
        public int OdüncAlId { get; set; }
        public int OgrenciId { get; set; }
        public int KitabId { get; set; }
        public string OdüncTarihi { get; set; }
        public string TeslimTarihi { get; set; }
        public string Durumu { get; set; }
    }
}
