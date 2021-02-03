using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Ogrenci:IEntity
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public string İsim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }        
        public string DogumTarihi {get;set;}
        public string Okulu { get; set; }
        public string Sınıfı { get; set; }
        public string Durumu { get; set; }
        public string Adres{ get; set; }
        public string Sifre { get; set; }
        //public string 

    }
}
