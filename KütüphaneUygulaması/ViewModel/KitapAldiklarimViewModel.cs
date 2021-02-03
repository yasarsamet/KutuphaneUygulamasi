using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class KitapAldiklarimViewModel
    {

        public KitapAldiklarimViewModel()
        {
            Kitaplistesi = new List<Kitaplar>();
            OduncAlListesi = new List<OduncAl>();
            Yazarlistesi = new List<Yazar>();
            KitapYazarListesi = new List<KitapYazar>();            
        }
        public List<Kitaplar> Kitaplistesi { get; set; }
        public List<OduncAl> OduncAlListesi { get; set; }
        public List<Yazar> Yazarlistesi { get; set; }
        public List<KitapYazar> KitapYazarListesi { get; set; }
       
    }
}
