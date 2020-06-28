using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EplangoTask.Core;
using EplangoTask.Core.Repositories;
using EplangoTask.Persistence.Context;
using EplangoTask.Persistence.Repositories;

namespace EplangoTask.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        private DemoDbContext _context;
        public UnitOfWork()
        {
            _context = new DemoDbContext();
            DepartmentRepository = new DepartmentRepository(_context);
            EmployeeRepository = new EmployeeDepartment(_context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}