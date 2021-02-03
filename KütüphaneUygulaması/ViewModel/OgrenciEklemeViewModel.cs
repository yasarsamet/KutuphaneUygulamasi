using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class OgrenciEklemeViewModel
    {
        public int Id { get; set; }

        public int OgrenciId { get; set; }  

        [Required(ErrorMessage = "İsminizi Girin")]
        public string Isim { get; set; }

        [Required(ErrorMessage = "Soyisiminizi Girin")]
        public string Soyisim { get; set; }

       [Required(ErrorMessage ="Telefon Numaranızı Girin")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Email adresini Girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Doğum Tarihinizi Girin")]
        public string DogumTarihi { get; set; }

        [Required(ErrorMessage = "Okulunuzu Girin")]
        public string Okulu { get; set; }

        [Required(ErrorMessage = "Sınıfınızı Girin")]
        public string Sınıfı { get; set; }

        public string Durumu { get; set; }

        [Required(ErrorMessage = "Adresinizi Girin")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Şifrenizi Girin")]
        public string Sifre { get; set; }

    }
}
