using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFriendly.Models
{
    public class BasketProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Piece { get; set; }
        public string Content { get; set; }
        public string PicturePath { get; set; }

        public decimal Fee()
        {
            return Piece * UnitPrice;
        }

        public string FeeText()
        {
            return string.Format("{0:0.00}", Fee());
        }

    }
}