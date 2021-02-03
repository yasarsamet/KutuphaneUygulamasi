using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class RezervasyonEttigimKitaplarViewModel
    {
        public RezervasyonEttigimKitaplarViewModel()
        {
            RezervasyonKitapListesi = new List<RezervasyonEttiklerim>();
        }

        public List<RezervasyonEttiklerim> RezervasyonKitapListesi { get; set; }
    }
}
