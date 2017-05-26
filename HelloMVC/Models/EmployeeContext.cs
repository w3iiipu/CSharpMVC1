using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees {get; set;}
        public DbSet<Department> Departments { get; set; }

        public System.Data.Entity.DbSet<BusinessLayer.People> People { get; set; }
    }
}