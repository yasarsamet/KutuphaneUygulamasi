using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class OduncAlViewModel
    {
        public OduncAlViewModel()
        {
            KitablarList = new List<SelectListItem>();
        }
        public int id { get; set; }
        public int OdüncAlId { get; set; }
        public int OgrenciId { get; set; }       
        public string OdüncTarihi { get; set; }
        public string Durumu { get; set; }

        [Required(ErrorMessage = "Teslim Tarihini Seçiniz")]
        public string TeslimTarihi { get; set; }
        
        public List<SelectListItem> KitablarList { get; set; }

        [Required(ErrorMessage = "Kitab Seçiniz")]
        public int KitabId { get; set; }

    
    }
}
