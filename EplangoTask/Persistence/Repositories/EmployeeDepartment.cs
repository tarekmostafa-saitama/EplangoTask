using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EplangoTask.Core.DbEntities;
using EplangoTask.Core.Repositories;

namespace EplangoTask.Persistence.Repositories
{
    public class EmployeeDepartment  :Repository<Employee,int>,IEmployeeRepository
    {
        public EmployeeDepartment(DbContext context) : base(context)
        {
        }
    }
}