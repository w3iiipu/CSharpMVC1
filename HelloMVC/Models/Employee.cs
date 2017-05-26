using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    //map model class to table in database
    [Table("TestEmployees")]

    public class Employee
    {
        public int ID { get; set;}
        public string Name { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
    }
}