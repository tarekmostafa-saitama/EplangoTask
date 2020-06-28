using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EplangoTask.Core.DbEntities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Department> DepartmentsManagement { get; set; }
        
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}