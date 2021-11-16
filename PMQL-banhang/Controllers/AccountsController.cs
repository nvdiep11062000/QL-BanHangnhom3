using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PMQL_banhang.Models;
using PMQL_banhang.Models.Process;

namespace PMQL_banhang.Controllers
{
    public class AccountsController : Controller
    {
        Encrytion encry = new Encrytion();
        QLbanhangDbContext db = new QLbanhangDbContext();
        // GET: Accounts
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                acc.Password = encry.PassWordEncrytion(acc.Password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Accounts");
            }
            return View(acc);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                string encrytionpass = encry.PassWordEncrytion(acc.Password);
                var model = db.Accounts.Where(m => m.UserName == acc.UserName && m.Password == encrytionpass).ToList().Count();
                // thong tin dang nhap chinh xac
                if(model == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.UserName, true);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thong tin dang nhap khong chinh xac");
                }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}