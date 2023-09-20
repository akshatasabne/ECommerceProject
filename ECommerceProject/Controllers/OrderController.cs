using ECommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Controllers
{
    public class OrderController : Controller
    {
        IConfiguration configuration;
        ProductCrud productCrud;
        RegisterCrud registerCrud;
        CartCrud cartCRUD;
        Product product;
        OrderCrud orderCrud;
        public OrderController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productCrud = new ProductCrud(this.configuration);
            registerCrud = new RegisterCrud(this.configuration);
            cartCRUD = new CartCrud(this.configuration);
            orderCrud = new OrderCrud(this.configuration);

        }

        [HttpGet]
        public ActionResult GetOrder(int id)
        {
            var model = productCrud.GetProductById(id);

            return View(model);
        }
        [HttpGet]
        public ActionResult GetOrderConfirm(int id)
        {
            try
            {
                Orders order = new Orders();
                string uid = HttpContext.Session.GetString("uid");
                order.Uid = Convert.ToInt32(uid);
                order.Id = id;
                order.Quantity = 1;
                int result = orderCrud.AddOrder(order);
                if (result == 1)
                    return RedirectToAction(nameof(MyOrder));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult MyOrder()
        {
            string uid = HttpContext.Session.GetString("uid");
            var result = orderCrud.MyOrder(Convert.ToInt32(uid));
            return View(result);

        }
    }

}





