using Microsoft.AspNet.Identity;
using PetFriendly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFriendly.Controllers
{
    public class BasketController : BaseController
    {
        // GET: Basket
        public ActionResult Index()
        {
            return View(Basket);
        }

        // GET: Basket/Payments
        [Authorize]
        public ActionResult Payments()
        {
            ViewBag.CustomerCityId = new SelectList(db.Sehirler.ToList(),"Id","SehirAd");

            return View();
        }

        // POST: Basket/Payments
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Payments(PaymentViewModel paymentVM)
        {
            if (paymentVM.MakePayment != Basket.Sum(x=>x.UnitPrice))
            {
                ModelState.AddModelError("MakePayment","Sepetinizde bir değişiklik yapılmıştır.Ürün bilgilerini kontrol ediniz.");
            }
            if (ModelState.IsValid)
            {
                bool paymentEnd = PaymentSafe(paymentVM.MakePayment, paymentVM.CustomerCCNo, paymentVM.CustomerPullDate, paymentVM.CustomerCVV);

                if (!paymentEnd)
                {
                    ModelState.AddModelError("PaymentFee", "Kredi kartınızdan ödeme alınamadı .Lütfen bilgilerinizi kontrol ediniz.");
                }
                if (paymentEnd)
                {
                    Order order = new Order
                    {
                        CustomerID = User.Identity.GetUserId(),
                        SehirId = paymentVM.CustomerCityId,
                        Name = paymentVM.CustomerName,
                        LastName = paymentVM.CustomerLastName,
                        Email = paymentVM.CustomerEmail,
                        Address = paymentVM.CustomerAddress,
                        Address2 = paymentVM.CustomerAddress2,
                        ZIP = paymentVM.CustomerZip,
                        PaymentTotal = paymentVM.MakePayment,
                        OrderTime = DateTime.Now,
                        OrderDetails = new List<OrderDetail>()
                    };

                    foreach (var item in Basket)
                    {
                        order.OrderDetails.Add(new OrderDetail
                        {
                            ProductId = item.ProductId,
                            ProductAd=item.ProductName,
                            UnitPrice=item.UnitPrice,
                            Piece=item.Piece
                        });
                    }
                    db.Order.Add(order);
                    db.SaveChanges();
                    Basket.Clear();

                    TempData["OrderId"] = order.Id;
                    return RedirectToAction("PaymentEnd","Basket");
                }

            }
            ViewBag.CustomerCityId = new SelectList(db.Sehirler.ToList(), "Id", "SehirAd");

            return View();
        }

        public ActionResult PaymentEnd()
        {
            return View();
        }

        private bool PaymentSafe(decimal makePayment, string customerCCNo, string customerPullDate, string customerCVV)
        {
            return true;
        }

        [HttpPost]
        public ActionResult BasketProductDelete(int id)
        {
            Basket.RemoveAll(x=>x.ProductId==id);
            decimal totalFee = Basket.Sum(x => x.Piece * x.UnitPrice);

            return Json(new
            {
                TotalFeeTL = string.Format("{0:0.00}₺", totalFee),
                TotalProduct = Basket.Count
            });
        }


        [HttpPost]
        public ActionResult AddToBasket(int id)
        {
            BasketProduct element = Basket.FirstOrDefault(x => x.ProductId == id);

            if (element == null)
            {
                Product product = db.Urunler.Find(id);

                element = new BasketProduct
                {
                    ProductId = id,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    Piece = 1,
                    Content = product.Content,
                    PicturePath = product.PicturePath
                };
                Basket.Add(element);
            }
            else
            {
                element.Piece++;
            }

            return Json(new { TotalPruduct = Basket.Count });
        }
    }
}