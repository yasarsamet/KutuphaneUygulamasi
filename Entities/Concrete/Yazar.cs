using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Yazar:IEntity
    {
        public int id { get; set; }
        public int YazarId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string DogumTarihi { get; set; }
        public string Adres { get; set; }
    }
}
