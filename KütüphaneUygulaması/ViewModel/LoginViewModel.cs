using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class LoginViewModel
    {
        //[Required(ErrorMessage = "Email Adresinizi Yazınız")]
        public string email { get; set; }

        [Required(ErrorMessage = "Şifrenizi Yazınız")]
        public string sifre{ get; set; }
    }
}
