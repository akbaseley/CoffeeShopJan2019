using CoffeeShopLabJan2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShopLabJan2019.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult UserDetails(User newUser)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CurrentUser = newUser;
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Registration failed. Try again.";
                return View("Error");
            }

        }

    }
}