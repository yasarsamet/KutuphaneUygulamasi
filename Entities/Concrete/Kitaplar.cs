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
        public int YayıneviId { get; set; }
        public int KitapId { get; set; }
        public string KitapAdı { get; set; }
        public string KitapSayfası { get; set; }
        public string KitapTürü { get; set; }
        public string BarkodNo { get; set; }        
    }
}


