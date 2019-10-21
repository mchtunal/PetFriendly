using PetFriendly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFriendly.Helpers
{
    public static class HelperExtensions
    {
        public static  List<BasketProduct>  Basket (this HtmlHelper htmlHelper)
        {
            var basket = htmlHelper.ViewContext.HttpContext.Session["basket"] as List<BasketProduct>;
           
            return basket;
        }

        public static decimal BasketFee(this HtmlHelper htmlHelper)
        {
            var basket = htmlHelper.ViewContext.HttpContext.Session["basket"] as List<BasketProduct>;

            return basket == null ? 0 : basket.Sum(x => x.Piece * x.UnitPrice);
        }
        public static int BasketPiece(this HtmlHelper htmlHlper)
        {
            var basket = htmlHlper.ViewContext.HttpContext.Session["basket"] as List<Product>;


            return basket == null ? 0 : basket.Count;
        }
        //this keyword i ile HtmlHelper classını extend(uzanmak) ettik.
        //artık View üzerinden @Html  nesnesi üzerinden bu metodu kulanbiliriz.
        public static MvcHtmlString ProductImg(this HtmlHelper htmlHelper, string picturePath, string className,object htmlAttributes)
        {
            if (string.IsNullOrEmpty(picturePath))
            {
                picturePath = "~/Images/product.png";
            }
            else
            {
                picturePath = "~/Upload/" + picturePath;
            }

            picturePath = VirtualPathUtility.ToAbsolute(picturePath);

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;

            TagBuilder tag = new TagBuilder("img");
            tag.MergeAttributes(attributes);
            tag.MergeAttribute("src", picturePath);

            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}