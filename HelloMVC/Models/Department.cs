using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    //using the table TestDepartment
    [Table("TestDepartments")]
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public  List<Employee> Employees { get; set; }
    }
}