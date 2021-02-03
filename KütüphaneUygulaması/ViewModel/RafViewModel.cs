using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class RafViewModel
    {
        public int Id { get; set; }
        public int RafNo { get; set; }
        public string RafBaslik { get; set; }
        public string BulunduguSalon { get; set; }
        public string BulunduguKat { get; set; }
    }
}
