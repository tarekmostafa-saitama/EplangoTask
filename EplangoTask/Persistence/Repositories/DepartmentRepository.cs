using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EplangoTask.Core.DbEntities;
using EplangoTask.Core.Repositories;

namespace EplangoTask.Persistence.Repositories
{
    public class DepartmentRepository : Repository<Department,int>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}