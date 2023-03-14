using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseProje.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public String Name { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public String Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public String UserName { get; set; }
        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage ="Eposta adresinizi doğru giriniz.")]
        public String Email { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public String Password { get; set; }
        [Required]
        [DisplayName("Tekrar Şifre")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor.")]
        public String RePassword { get; set; }

    }
}