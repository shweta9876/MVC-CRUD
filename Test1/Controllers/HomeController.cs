using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class HomeController : Controller
    {
        DbEntities Db = new DbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            
            Employee employee = new Employee()
            {
                Id = 2,
                Name = "b",
                Email = "d"
            };

            Db.Employees.Add(employee);
            Db.SaveChanges();
            ViewBag.Message = "New Employee Created! where Id = " + employee.Id + "Name = " + employee.Name + "Email="+ employee.Email ;
            return View();
        }

        public ActionResult Read()
        {
            DbEntities Db = new DbEntities();
            var id = 2;
            var employee = (from emp in Db.Employees where emp.Id == id select emp).FirstOrDefault();
            return View();
        }
        public ActionResult Update()
        {
            DbEntities Db = new DbEntities();
            var id = 2;
            var employee = (from emp in Db.Employees where emp.Id == id select emp).FirstOrDefault();
            if (employee != null)
            {
                employee.Name = "shweta";
                employee.Email = "shweta@gmail.com";
                Db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
            }
            return View();
        }
        public ActionResult Delete()
        {
            DbEntities Db = new DbEntities();
            var id = 2;
            var employee = (from emp in Db.Employees where emp.Id == id select emp).FirstOrDefault();
            if (employee != null)
            {
                Db.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                Db.SaveChanges();
            }
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
    }
}