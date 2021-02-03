using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class ProfilEditViewModel
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string DogumTarihi { get; set; }
        public string Okulu { get; set; }
        public string Sinifi { get; set; }
        public string Durumu { get; set; }
        public string Adres { get; set; }
        public string Sifre { get; set; }
    }
}
