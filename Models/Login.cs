using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseProje.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public String UserName { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public String Password { get; set; }
        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}