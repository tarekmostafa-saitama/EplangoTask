using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EplangoTask.Core.DbEntities;

namespace EplangoTask.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee,int>
    {
    }
}
