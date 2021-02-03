using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Raf:IEntity
    {
        public int Id { get; set; } 
        public int RafNo { get; set; }
        public string RafBaslik { get; set; }
        public string BulunduguSalon { get; set; }
        public string BulunduguKat { get; set; }
    }
}
