using PetFriendly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFriendly.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int? categoryId,string search,string alignment)
        {
            IQueryable<Product> que = db.Urunler;

            if (categoryId != null)
            {
                que = que.Where(p=>p.CategoryId == categoryId);
            }
            if (!string.IsNullOrEmpty(search))
            {
                que = que.Where(p => p.ProductName.Contains(search));
            }

            switch (alignment)
            {
                case "fiyatArtan":
                    que = que.OrderBy(x=>x.UnitPrice);
                break;
                case "fiyatAzalan":
                    que = que.OrderByDescending(x => x.UnitPrice);
                    break;
                case "isimArtan":
                    que = que.OrderBy(x => x.ProductName);
                    break;
                case "isimAzalan":
                    que = que.OrderByDescending(x => x.ProductName);
                    break;
                default:
                    break;

            };

            ViewBag.alignment = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{Value="fiyatArtan", Text="Fiyata Göre Artan"},
                new SelectListItem{Value="fiyatAzalan", Text="Fiyata Göre Azalan"},
                new SelectListItem{Value="isimArtan", Text="İsme Göre (A-Z)"},
                new SelectListItem{Value="isimAzalan", Text="İsme Göre (Z-A)"}
            } , "Value","Text", alignment);

            return View(que.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your services  page.";

            return View();
        }

        public ActionResult CategoryPartial()
        {
            return PartialView("_Category", db.Kategoriler.OrderBy(x => x.CategoryName).ToList());
        }

    }
}