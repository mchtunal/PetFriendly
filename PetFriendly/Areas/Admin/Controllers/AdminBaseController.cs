using PetFriendly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFriendly.Areas.Admin.Controllers
{
    //[Authorize(Roles ="Admin")]
    //New'lenemesin diye abstract class haline getirdik.
    public abstract class AdminBaseController : Controller
    {
        //Miras Alanlar kullanabilsin diye protected.Konum: dışarı kapalı.
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            //Controller kapadıldıktan sonra Dispose çağırdık.Ve db nesnesini dispose ettik.Yeni bir controller oluşturulurken tekrar db nesnesi oluşturulacak.
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}