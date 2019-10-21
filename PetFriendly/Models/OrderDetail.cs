using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetFriendly.Models
{
    [Table("SiparisDetaylar")]
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductAd { get; set; }
        public decimal UnitPrice { get; set; }
        public int Piece { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}