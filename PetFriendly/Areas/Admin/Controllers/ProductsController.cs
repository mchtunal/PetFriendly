using PetFriendly.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFriendly.Areas.Admin.Controllers
{
    public class ProductsController : AdminBaseController
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(db.Urunler.ToList());
        }

        // GET: Admin/Products/NewProduct
        public ActionResult NewProduct()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler.ToList(), "id", "CategoryName", 1);
            return View();
        }


        // POST: Admin/Products/NewProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewProduct(Product product, HttpPostedFileBase photo)
        {
            PictureErrorCheck(photo);
;
            if (ModelState.IsValid)
            {
                var fileName = DownLoadFile(photo);

                product.PicturePath = fileName;

                db.Urunler.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler.ToList(), "id", "CategoryName", 1);

            return View();
        }

        //POST:Admin/Products/ProductDelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductDelete(int id)
        {
            Product deleted = db.Urunler.Find(id);

            if (!string.IsNullOrEmpty(deleted.PicturePath))
            {
                string pictureFullPath = Server.MapPath("~/Upload/" + deleted.PicturePath);
                if (System.IO.File.Exists(pictureFullPath))
                {
                    System.IO.File.Delete(pictureFullPath);
                }
            }

            db.Urunler.Remove(deleted);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET:Admin/Products/UpdateProduct
        public ActionResult UpdateProduct(int id)
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler.ToList(), "Id", "CategoryName");
            return View(db.Urunler.Find(id));
        }

        //POST:Admin/Products/UpdateProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(Product product,HttpPostedFileBase photo)
        {
            PictureErrorCheck(photo);
            if (ModelState.IsValid)
            {
                var fileName = DownLoadFile(photo);

                Product dbProduct = db.Urunler.Find(product.Id);

                if (!string.IsNullOrEmpty(dbProduct.PicturePath))
                {
                    if (!string.IsNullOrEmpty(dbProduct.PicturePath))
                    {
                        var pictureFullPath = Server.MapPath("~/Upload/" + dbProduct.PicturePath);
                        if (System.IO.File.Exists(pictureFullPath))
                        {
                            System.IO.File.Delete(pictureFullPath);
                        }
                    }
                    dbProduct.PicturePath = fileName;
                }
                dbProduct.ProductName = product.ProductName;
                dbProduct.UnitPrice = product.UnitPrice;
                dbProduct.CategoryId = product.CategoryId;
                dbProduct.Content = product.Content;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler.ToList(), "Id", "CategoryName");
            return View(product);
        }


        private void PictureErrorCheck( HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                if (!photo.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("photo", "Lütfen bir resim dosyası seçiniz.");
                }

                if (photo.ContentLength > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("photo", "Seçtiğiniz resim dosya boyutunun 2 mb'dan büyük olmamasına dikkat ediniz.");
                }

                Bitmap bmp = new Bitmap(photo.InputStream);
                if (bmp.Width != bmp.Height)
                {
                    ModelState.AddModelError("photo", "Eklemeye çalıştıgınız resim 1*1 boyutunda olmalıdır");
                }

            }
        }

        private string DownLoadFile(HttpPostedFileBase photo)
        {
            if (photo != null && photo.ContentLength > 0)
            {
                var ext = Path.GetExtension(photo.FileName);
                var fileName = Guid.NewGuid() + ext;
                var savePath = Server.MapPath("~/Upload/" + fileName);

                photo.SaveAs(savePath);
                return fileName;
            }
            return "";
        }

    }
}