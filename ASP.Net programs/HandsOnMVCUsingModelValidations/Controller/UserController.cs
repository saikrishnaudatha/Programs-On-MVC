using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HandsOnMVCUsingModelValidations.Models;
using HandsOnMVCUsingModelValidations.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HandsOnMVCUsingModelValidations.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Country= new SelectList(new string[] { "India", "US", "UK", "Canada" });
            return View();
        }
        [HttpPost]
        public IActionResult Create(User item)
        {
            //UserRepository repository = new UserRepository();
            //repository.Add(item);
            //return RedirectToAction("Login"); 


            if (ModelState.IsValid)
            {
                //add Model data to db table
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string uname,string pwd)
        {
            UserRepository repository = new UserRepository();
            User user = repository.Validate(uname, pwd);
            if(user!=null)
            {
                return RedirectToAction("Details",user);   //Here;Object is passed as parameter
            }
            else
            {
                ViewData["err"] = "Invalid Credentials";
                return View();
            }
        }

        public IActionResult Details([Bind (include : "Name")]User item)
        {
            return View(item);
        }


    }
}