using EmployeeInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {                      
            return View();
        }
        public IActionResult Data_entry()
        {
            EmployeeController model = new EmployeeController();
            DataTable dt = model.GetAllEmployee();
            return View("Data_entry", dt);        
        }

        public ActionResult InsertRecord(Microsoft.AspNetCore.Http.IFormCollection frm, string action)
        {
                EmployeeController model = new EmployeeController();
                string FirstName = frm["FirstName"];                 
                string MiddleName = frm["MiddleName"];
                string LastName = frm["LastName"];              
                int status = model.InsertEmployee(FirstName,  MiddleName, LastName);
                return RedirectToAction("Data_entry");
        }

        public ActionResult Edit(int Id)
        {
            EmployeeController model = new EmployeeController();
            DataTable dt = model.GetEmployeeInfo(Id);
            return View("Edit_record", dt);
        }

        public ActionResult Delete(int Id)
        {
            EmployeeController model = new EmployeeController();
            DataTable dt = model.GetEmployeeInfo(Id);
            return View("Delete_record", dt);
        }

        

        public ActionResult SaveUpdate(Microsoft.AspNetCore.Http.IFormCollection frm, string action)
        {
            EmployeeController model = new EmployeeController();
            int Id = Convert.ToInt32(frm["Id"]); 
            string FirstName = frm["FirstName"];
            string MiddleName = frm["MiddleName"];
            string LastName = frm["LastName"];
            int status = model.UpdateEmployee(Id, FirstName, MiddleName, LastName);
            return RedirectToAction("Data_entry");
        }

        public ActionResult DeleteRecord(Microsoft.AspNetCore.Http.IFormCollection frm, string action)
        {
            EmployeeController model = new EmployeeController();
            int Id = Convert.ToInt32(frm["Id"]);
            int status = model.DeleteEmployee(Id);
            return RedirectToAction("Data_entry");
        }



        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult Insert_record()
        {
            return View();
        }


        public IActionResult Logout()
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
