using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewModel
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email yaz")]
        public  string email { get; set; }
    }
}
