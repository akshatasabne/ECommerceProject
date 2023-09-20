using ECommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Controllers
{
    public class CartController : Controller
    {
        IConfiguration configuration;
        ProductCrud productCrud;
        CartCrud cartCrud;
        public CartController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productCrud = new ProductCrud(this.configuration);
            cartCrud = new CartCrud(this.configuration);
        }
        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Orders(int id)
        {
            var model = productCrud.GetProductById(id);
            return View(model);
        }
      
        // PO  [HttpGet]ST: CartController/Create
        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            try
            {
                Cart cart = new Cart();
                string uid = HttpContext.Session.GetString("uid");
                cart.Uid = Convert.ToInt32(uid);
                cart.Id = id;
                cart.Quantity = 1;
                int result = cartCrud.AddTOCart(cart);
                if (result == 1)
                    return RedirectToAction(nameof(ViewCart));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        // GET: CartController/Edit/5
        public ActionResult ViewCart(int id)
        {
            string uid = HttpContext.Session.GetString("uid");
            var model = cartCrud.ViewCart(Convert.ToInt32(uid));
            return View(model);

        }
        //public ActionResult ConfirmOrder(int id)
        //{
        //    var mode = cartCrud.ConfirmOrder(id);
        //    return View(model);
        //}
        public ActionResult RemoveCart(int id)
        {
            try
            {
                var result = cartCrud.DeleteCart(id);

                return RedirectToAction(nameof(ViewCart));

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
       

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
