using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetFriendly.Models
{
    [Table("Siparisler")]
    public class Order
    {
        //PrimaryKey
        public int Id { get; set; }

        //ForeignKey 
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }


        //ForeignKey 
        public int SehirId { get; set; }


        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "E-mail Adres")]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        public string Address { get; set; }


        public string Address2 { get; set; }


        [Required]
        public string ZIP { get; set; }

        public decimal PaymentTotal { get; set; }


        [Required]
        public DateTime? OrderTime { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ApplicationUser Customer { get; set; }
        public virtual Sehir Sehir { get; set; }
    }
}
