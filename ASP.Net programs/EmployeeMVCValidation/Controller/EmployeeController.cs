using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeMVCValidation.Models;
using EmployeeMVCValidation.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeMVCValidation.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Designation = new SelectList(new string[] { "Trainee", "Fresher", "Team Leader" });
            ViewBag.Projectname = new SelectList(new string[] { "Emart","Student", "Employee" });
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            EmployeeRepository erepository = new EmployeeRepository();
            erepository.Add(emp);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(int eid, string pwd)
        {
            EmployeeRepository erepository = new EmployeeRepository();
            Employee emp = erepository.Validate(eid, pwd);
            if (emp != null)
            {
                return RedirectToAction("Details", emp); 
            }
            else
            {
                ViewData["err"] = "Invalid Credentials";
                return View();
            }
        }

        public IActionResult Details(Employee emp)
        {
            return View(emp);
        }
    }
}