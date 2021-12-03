using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoAppJLT.Models;



namespace MVCDemoAppJLT.Controllers
{
    public class EmpController : Controller
    {
        EmpDataStore empDataStore = new EmpDataStore();
        // GET: Emp
        public ActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            {
                try
                {
                    employeeList = empDataStore.GetEmployee();
                }
                catch (Exception ex)
                {
                    ViewBag.exception = ex.Message;
                }
                return View(employeeList);
            }

        }
        public ActionResult Display(int Id)
        {
            Employee employee = new Employee();
            try
            {
                employee = empDataStore.GetEmployeeById(Id);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
            public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    empDataStore.AddEmployee(employee);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
        return View(employee);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    Employee employee = empDataStore.GetEmployeeById(id);
                    return View(employee);
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    empDataStore.UpdateEmployee(employee);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(employee);

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    Employee employee = empDataStore.GetEmployeeById(id);
                    return View(employee);
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    empDataStore.DeleteEmployee(employee);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(employee);

        }
    }
}