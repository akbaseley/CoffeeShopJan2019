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
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            return View();
        }

        public ActionResult About()
        {
            if (!TempData.ContainsKey("HappyMessage"))
            {
                TempData.Add("HappyMessage", "Happy Valentine's Day!");
            }

            ViewBag.Message = "This is the about page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (TempData["HappyMessage"] != null)
            {
                ViewBag.Message = TempData["HappyMessage"];
                TempData["HappyMessage"] = TempData["HappyMessage"];
            }

            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult UserDetails(User newUser)
        {
            //add sessions
            if (Session["CurrentUser"] != null)
            {
                newUser = (User)Session["CurrentUser"];
                ViewBag.CurrentUser = newUser;
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ViewBag.CurrentUser = newUser;
                    Session["CurrentUser"] = newUser;
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Registration failed. Try again.";
                    return View("Error");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Remove("CurrentUser");
            return RedirectToAction("Index");
        }

    }
}