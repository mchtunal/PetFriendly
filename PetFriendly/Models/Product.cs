using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetFriendly.Models
{
    [Table("Urunler")]
    public class Product
    {
        public int Id { get; set; }


        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }


        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Ürün Alanı Zorunludur.")]
        [StringLength(100, ErrorMessage = "Ürün adı max 100 harften oluşmalıdır.")]
        public string ProductName { get; set; }



        [Display(Name = "Açıklama-İçerik")]
        public string Content { get; set; }



        [Display(Name = "Birim Fiyatı")]
        public decimal UnitPrice { get; set; }



        [Display(Name = "Resim Yolu")]
        [StringLength(200,ErrorMessage ="Resim yolu maksimum 200 karakteri geçemez.")]
        public string PicturePath { get; set; }

        public virtual Category Categories { get; set; }


    }
}