using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloMVC.Models;

namespace HelloMVC.Controllers
{
    public class EmployeeController : Controller
    {
  
        public ActionResult Index(int departmentId)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();
            
            return View(employees);
        }
    
        public ActionResult Details(int ID)
        {

            //create an entity context object
            EmployeeContext employeeContext = new EmployeeContext();
            //employee context returns employee class  - single returns one entry - all stored in employee object
            Employee employee = employeeContext.Employees.Single(emp=> emp.ID == ID);
            //hand employee object to view
            return View(employee);
        }

    }
}