using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class RezervasyonViewModel
    {
        public int Id { get; set; }
        public int RezervasyonId { get; set; }
        public int OgrenciId { get; set; }
        public int KitabId { get; set; }
        public bool IsDeleted { get; set; }        
        public string Tarih { get; set; }
        public DateTime? Zaman { get; set; }



    }
}
