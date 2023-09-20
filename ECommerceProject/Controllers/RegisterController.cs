using ECommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Controllers
{
    public class RegisterController : Controller
    {
        IConfiguration configuration;
        ProductCrud productCrud;
        RegisterCrud Crud;
        LogInCrud logInCrud;

        public object Session { get; private set; }

        public RegisterController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productCrud = new ProductCrud(this.configuration);
            Crud = new RegisterCrud(this.configuration);
            logInCrud = new LogInCrud(this.configuration);
        }
        // GET: UserController
        public ActionResult Index(int pg=1)
        {
            var model = productCrud.GetProducts();
            const int pagesize = 8;
            if (pg < 1)
            {
                pg = 1;
            }

            int recscount = model.Count();

            var pager = new Pager(recscount, pg, pagesize);

            int recskip = (pg - 1) * pagesize;

            var data = model.Skip(recskip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(data);
        }
        public ActionResult UserList()
        {
            var model = Crud.GetAllUser();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Registration()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Register register)
        {
            try
            {
                int result = Crud.AddUser(register);
                if (result >= 1)
                    return RedirectToAction(nameof(Login));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }
        public ActionResult VeiwMorePage(int id)
        {
            var model = productCrud.GetProductById(id);
            return View(model);
        }


        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Register register)
        {
            try
            {
                var model = Crud.Login(register.UserName, register.Password);
                if (model.Uid>0)
                {
                    HttpContext.Session.SetString("RoleId", model.RoleId.ToString());
                    HttpContext.Session.SetString("uid", model.Uid.ToString());
                    HttpContext.Session.SetString("username", model.UserName);


                    if (model.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else if (model.RoleId == 0)
                    {
                        return RedirectToAction("Index", "Register");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // POST: UserController/Delete/5
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