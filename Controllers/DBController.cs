using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoAppJLT.Models;

namespace MVCDemoAppJLT.Controllers
{
    public class DBController : Controller
    {
        DBData dBData = new DBData();

        // GET: DB
        public ActionResult ConnectedExample()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = dBData.ConnectedDemo();
            }
            catch (Exception ex)
            {
                ViewBag.exception = ex.Message;
            }
            return View(employees);
        }
        public ActionResult DisconnectedExample()
        {
            List<Department> departments = new List<Department>();
            try
            {
                departments = dBData.DisconnectedDemo();
            }
            catch (Exception ex)
            {
                ViewBag.exception = ex.Message;
            }
            return View(departments);
        }
    }
}