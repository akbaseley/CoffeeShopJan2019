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
        List<Item> ItemList = new List<Item>() {

            new Item("Hot Chocolate", "Milk, Cocoa, Sugar, Fat", 1.99),
            new Item("Latte",  "Milk, Coffee", 1.99),
            new Item("Coffee",  "Coffee, Water", 1.00),
            new Item("Tea", "Black Tea", 1.00),
            new Item("Frozen Lemonade",  "Lemon, Sugar, Ice", 1.99)
        };

        List<Item> ShoppingCart = new List<Item>();

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

        public ActionResult ListItems()
        {
            ViewBag.ItemsList = ItemList;
            return View();
        }

        public ActionResult AddItem(string itemName)
        {
            if(Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Item>)Session["ShoppingCart"];
            }

            foreach(Item item in ItemList)
            {              //find item in list
                if(item.ItemName == itemName)
                {
                    ShoppingCart.Add(item);
                }
            }

            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("ListItems");
        }
    }
}