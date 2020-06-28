using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EplangoTask.Core.DbEntities;

namespace EplangoTask.Core.Repositories
{
    public interface IDepartmentRepository : IRepository<Department,int>
    {
    }
}