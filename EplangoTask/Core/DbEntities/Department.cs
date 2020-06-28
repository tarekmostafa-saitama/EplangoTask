using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EplangoTask.Core.DbEntities
{
   
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
  
        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

}