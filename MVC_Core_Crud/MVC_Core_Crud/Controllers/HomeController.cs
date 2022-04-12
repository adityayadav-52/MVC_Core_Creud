using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Core_Crud.DB_Context;
using MVC_Core_Crud.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        MytableContext dbobj = new MytableContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<EmpRes> empobj = new List<EmpRes>();

            var res = dbobj.MyInfos.ToList();
            foreach (var item in res)
            {
                empobj.Add(new EmpRes
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Salary = item.Salary,
                    City = item.City,
                    Dept = item.Dept,
                });
            }

            return View(empobj);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(EmpRes empobj)
        {
            MyInfo tblobj = new MyInfo();
            tblobj.Id = empobj.Id;
            tblobj.Name = empobj.Name;
            tblobj.Email = empobj.Email;
            tblobj.Salary = empobj.Salary;
            tblobj.City = empobj.City;
            tblobj.Dept = empobj.Dept;

            if (empobj.Id == 0)
            {
                dbobj.MyInfos.Add(tblobj);
                dbobj.SaveChanges();
            }
            else
            {
                dbobj.Entry(tblobj).State = EntityState.Modified;
                dbobj.SaveChanges();
            }

            return RedirectToAction("Index","Home");
        }

        public IActionResult Edit(int id)
        {
            EmpRes empobj = new EmpRes();
            var edit = dbobj.MyInfos.Where(a => a.Id == id).First();
            empobj.Id = edit.Id;
            empobj.Name = edit.Name;
            empobj.Email = edit.Email;
            empobj.Salary = edit.Salary;
            empobj.City = edit.City;
            empobj.Dept = edit.Dept;

            //ViewBag.id = edit.Id;

            return View("Add",empobj);
        }
        public IActionResult Delete(int id)
        {
            var del = dbobj.MyInfos.Where(a => a.Id == id).FirstOrDefault();
            dbobj.MyInfos.Remove(del);
            dbobj.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
