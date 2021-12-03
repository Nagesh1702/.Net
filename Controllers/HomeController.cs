using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoAppJLT.Models;

namespace MVCDemoAppJLT.Controllers
{
    public class HomeController : Controller
    {
        //Action
        public ActionResult Index()
        {
            return View(); //Html View
        }
        public ActionResult Info()
        {
            return View();
        }
        public ActionResult GetData(int id = 0)
        {
            ViewBag.msg = "Data :" + id;
            return View();
        }
        [Route("Home/Greet/{userName?}")]
        public ActionResult Greet(String userName = "Nagesh")
        {
            ViewBag.msg = "Hello " + userName;
            return View();
        }
        [Route("Home/Add/{n1?}/{n2?}")]
        public ActionResult Add(int n1 = 0, int n2 = 0)
        {
            int add = n1 + n2;
            ViewBag.msg = "Addition is = " + add;
            return View();

        }

        public ActionResult ModelDemo()
        {
            Employee employee = new Employee() { EmpId = 101, EmpName = "Nagesh", Salary = 10000 };

            //Models binder
            return View(employee);
        }

        public ActionResult CollectionDemo()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { EmpId = 101, EmpName = "Yogesh", Salary = 20000 });
            employees.Add(new Employee() { EmpId = 102, EmpName = "Nagesh", Salary = 40000 });
            employees.Add(new Employee() { EmpId = 103, EmpName = "Raj", Salary = 60000 });
            employees.Add(new Employee() { EmpId = 104, EmpName = "Nitin", Salary = 65000 });
            employees.Add(new Employee() { EmpId = 105, EmpName = "Pranit", Salary = 750000 });
            employees.Add(new Employee() { EmpId = 106, EmpName = "Nikhil", Salary = 80000 });

            return View(employees);
        }
        public ActionResult EmployeeForm()
        {
            return View(new Employee());
        }
        public ActionResult PostEmployeeData(Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                return View(employee);
            }
            return View("EmployeeForm",employee);
        }
    }
}