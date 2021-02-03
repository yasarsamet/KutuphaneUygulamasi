using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class KitapListesiViewModel
    {

        public KitapListesiViewModel()
        {
            Kitaplistesi = new List<Kitaplar>();
            Yazarlistesi = new List<Yazar>();
            KitapYazarListesi = new List<KitapYazar>();
            OduncAlListesi = new List<OduncAl>();
            RafListesi = new List<Raf>();
            RezervasyonListesi = new List<Rezervasyon>();
        }
        public List<Kitaplar> Kitaplistesi { get; set; }

        public List<Yazar> Yazarlistesi { get; set; }
        public List<KitapYazar> KitapYazarListesi { get; set; }
        public List<OduncAl> OduncAlListesi { get; set; }
        public List<Raf> RafListesi { get; set; }
        public List<Rezervasyon> RezervasyonListesi { get; set; }
    }
}
