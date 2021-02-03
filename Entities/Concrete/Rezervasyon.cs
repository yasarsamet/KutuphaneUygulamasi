using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rezervasyon : IEntity
    {
        //public int Id { get; set; }
        //public int RezervasyonId { get; set; }
        //public int OgrenciId { get; set; }
        //public int KitabId { get; set; }
        //public bool IsDeleted { get; set; }
        //public int Süresi { get; set; }
        //public string Tarih { get; set; }
        public int Id { get; set; }
        public int RezervasyonId { get; set; }
        public int OgrenciId { get; set; }
        public int KitabId { get; set; }
        public bool IsDeleted { get; set; }
        public string Tarih { get; set; }
        public DateTime? Zaman { get; set; }


    }
}
