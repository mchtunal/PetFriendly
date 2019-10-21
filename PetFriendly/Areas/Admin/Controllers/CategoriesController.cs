using PetFriendly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFriendly.Areas.Admin.Controllers
{
    public class CategoriesController : AdminBaseController
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }

        // GET: Admin/Categories/NewCategory
        public ActionResult NewCategory()
        {
            return View();
        }
        // POST: Admin/Categories/NewCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriler.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: Admin/Categories/UpdateCategory
        public ActionResult UpdateCategory(int id)
        {
            return View(db.Kategoriler.Find(id));
        }



        // POST: Admin/Categories/UpdateCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




        // POST:Admin/Categories/CategoryDelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryDelete(int id)
        {
            Category deleted = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(deleted);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}