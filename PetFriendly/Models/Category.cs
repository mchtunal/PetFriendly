using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetFriendly.Models
{
    [Table("Kategoriler")]
    public class Category
    {
        //Ürünleri seed metodunda null oldugu için ekleyemiyoruz.Bunun için List gibi bir yapının içinde boş şekilde tutmamız lazım.Lakin biz daha kullanışlı olsun diye "HasSet" i kullanacagız.Sebebi ise bir ürün eklendi ise bir daha eklenmemesi için.
        //Bunu da Ctor içinde new leyerek oluşturuyoruz.
        public Category()
        {
            Products = new HashSet<Product>();
        }


        public int Id { get; set; }

        [Display(Name ="Kategori")]
        [Required(ErrorMessage ="Kategori Alanı Zorunludur.")]
        [StringLength(100,ErrorMessage ="Kategori adı max 100 harften oluşmalıdır.")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}