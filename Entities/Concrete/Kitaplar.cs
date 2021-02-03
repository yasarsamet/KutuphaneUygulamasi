using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Kitaplar :IEntity
    {
        public int Id { get; set; }
        public int RafId { get; set; }
        public int YayineviId { get; set; }
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string KitapSayfasi { get; set; }
        public string KitapTürü { get; set; }
        public string BarkodNo { get; set; }        
    }
}


