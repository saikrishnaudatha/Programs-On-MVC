using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoOnCookies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoOnCookies.Controllers
{
    [Route("[controller]/[action]")]
    public class CookieController : Controller
    {
        public readonly UserAccountContext _context;
        public CookieController(UserAccountContext context)
        {
            this._context = context;
        }
        // GET: Cookie

           
            [HttpGet]
        public ActionResult RegisterUser()

        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(UserAccount ua)
        {
            try
            {
                _context.Add(ua);
                _context.SaveChanges();
                ViewBag.message = ua.UserName + " has got successfully Registered";
                return RedirectToAction("Login");
            }
            catch(Exception e)
            {
                ViewBag.message= ua.UserName + " Registration Failed!!!";
                return View();
            }
           
        }
       
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Login(UserAccount uc)
        {
            var logUser = _context.UserAccounts.Where(e => e.UserName == uc.UserName && e.Password == uc.Password).ToList();
            if (logUser.Count == 0)
            {
                ViewBag.message = "Not a valid User";
                return View();
            }
            else
            {
                //To store Sessoin Values
                HttpContext.Session.SetString("UName", uc.UserName);
                //HttpContext.Session.SetString("LastLogin", DateTime.Now.ToString());
                return RedirectToAction("CreateDashBoard");
            }
        }


        public ActionResult LogOut()
        {
            Response.Cookies.Append("LastLogin", DateTime.Now.ToString());
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDashBoard()
        {
            //To Retrieve Session Values
            if (HttpContext.Session.GetString("UName") != null)
            {
                ViewBag.uname = HttpContext.Session.GetString("UName").ToString();
                //ViewBag.ll = HttpContext.Session.GetString("LastLogin").ToString();
                if(Request.Cookies["LastLogin"]!=null)
                ViewBag.ll = Request.Cookies["LastLogin"].ToString();
            }
            return View();
        }

        // GET: Cookie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cookie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cookie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cookie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cookie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cookie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cookie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}