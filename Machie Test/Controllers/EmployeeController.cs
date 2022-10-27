using Machie_Test.DAL;
using Machie_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Machie_Test.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Employee List
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeGetList() {
            EmployeeDA da = new EmployeeDA();
            List<Employee> employees =da.EmployeeGet();

            return Json(new {  data = employees, JsonRequestBehavior.AllowGet });
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GiftDelete(int id)
        {
            EmployeeDA da = new EmployeeDA();
            da.EmployeeDelete(id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}