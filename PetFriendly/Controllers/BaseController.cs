using PetFriendly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFriendly.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        public List<BasketProduct> Basket
        {
            get
            {
                if (Session["basket"]==null)
                {
                    Session["basket"] = new List<BasketProduct>();
                }
                return (List<BasketProduct>)Session["basket"];
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session["basket"] == null)
            {
                Session["basket"] = new List<BasketProduct>();
            }
            
            base.OnActionExecuting(filterContext);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}