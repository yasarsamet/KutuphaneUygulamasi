using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class NewPasswordViewModel
    {
        [Required(ErrorMessage = "Lütfen Yeni Şifresini Yazınz")]
        public string Sifre { get; set; }
    }
}
