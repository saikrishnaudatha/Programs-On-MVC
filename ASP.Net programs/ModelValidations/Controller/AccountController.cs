using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HandsOnModelValidations.Models;

namespace HandsOnModelValidations.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login item)
        {
            if (ModelState.IsValid)          //Model State Validates model
            {
                return RedirectToAction("Index");
            }
            else
                return View();
                
                
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Employee item)
        {
            if (ModelState.IsValid)
            {
                //add Model data to db table
                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}