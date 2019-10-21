using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetFriendly.Models
{
    public class PaymentViewModel
    {
        [Required (ErrorMessage ="Zorunlu Alan!")]
        [Display(Name ="İsim")]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "Soyisim")]
        public string CustomerLastName { get; set; }

        [EmailAddress(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "E-mail Adresi")]
        public string CustomerEmail { get; set; }



        [Required(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "Adres")]
        public string CustomerAddress { get; set; }

        
        public string CustomerAddress2 { get; set; }


        [Required(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "Şehir")]
        public int CustomerCityId { get; set; }



        [Required(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "Posta Kodu")]
        public string CustomerZip { get; set; }



        [Required(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "Kredi Kartı Sahibi")]
        public string CustomerCC { get; set; }



        [Required(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "Kredi Kartı No")]
        public string CustomerCCNo { get; set; }



        [Required(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "Kredi Kartı Son Kullanma Tarihi")]
        public string CustomerPullDate { get; set; }



        [Required(ErrorMessage = "Zorunlu Alan!")]
        [Display(Name = "Cvv Kodu")]
        public string CustomerCVV { get; set; }



        [Required(ErrorMessage = "Zorunlu")]
        public decimal MakePayment { get; set; }
    }
}