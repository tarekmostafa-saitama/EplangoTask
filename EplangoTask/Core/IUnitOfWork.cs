using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EplangoTask.Core.Repositories;

namespace EplangoTask.Core
{
    public interface IUnitOfWork
    {
         IDepartmentRepository DepartmentRepository { get; set; }
         IEmployeeRepository EmployeeRepository { get; set; }

         void Complete();
    }
}
