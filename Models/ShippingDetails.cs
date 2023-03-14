using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseProje.Models
{
    public class ShippingDetails
    {
       
        public string UserName { get; set; }
        [Required(ErrorMessage="Lütfen Adres Başlığı giriniz")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen Adresi giriniz")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen şehri giriniz")]
        public string sehir{ get; set; }
        [Required(ErrorMessage = "Lütfen semti giriniz")]
        public string semt { get; set; }
        [Required(ErrorMessage = "Lütfen mahelleyi giriniz")]
        public string mahalle{ get; set; }

        public string postakodu { get; set; }
    }
}