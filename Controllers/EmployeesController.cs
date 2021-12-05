using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dhanashree.Data;
using Dhanashree.Models;
using Microsoft.AspNetCore.Mvc;


namespace Dhanashree.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeesDbContext obj;
        public EmployeesController(EmployeesDbContext _obj)
        {
            obj = _obj;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> elist = obj.Employees;
            return View(elist);
        }


        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Edit(int id)
        {
            var isavailable = obj.Employees.SingleOrDefault(x => x.Id == id);
            return View(isavailable);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
            obj.Employees.Add(employee);
           
            obj.SaveChanges();
           
            return RedirectToAction("Index");
            }
            else
            {
                return View(employee);

            }
        }

   
        public IActionResult Delete( int id)
        {
            var isavailable = obj.Employees.SingleOrDefault(x => x.Id == id);

           
            if (isavailable != null)
            {
                obj.Employees.Remove(isavailable);
                obj.SaveChanges();

                //var employer = new Employees { Id = 1 };
                //obj.Employees.Attach(employer);
                //obj.Employees.Remove(employer);
                //obj.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }
    }
}
