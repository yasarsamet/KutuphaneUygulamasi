using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class KitapYazar:IEntity
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public int YazarId { get; set; }
        public string KitapBasimTarihi { get; set; }
    }
}
