using PetFriendly.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFriendly.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        // GET: Admin/Dashboard
        [Obsolete]
        public ActionResult Index()
        {
            var sonuc = db.Order
                .GroupBy(s => EntityFunctions.TruncateTime(s.OrderTime))
                .Select(gruop => new GunlukCiro
                {
                    Gun = gruop.Key,
                    SiparisAdet = gruop.Count(),
                    Ciro = gruop.Sum(x => x.PaymentTotal)

                }).ToList();

            return View(sonuc);
        }

       
    }
}