using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EplangoTask.Core;
using EplangoTask.Core.DbEntities;
using EplangoTask.Persistence;
using EplangoTask.Persistence.ViewModels;

namespace EplangoTask.Controllers
{
    public class EmployeeController : Controller
    {
        private IUnitOfWork unitOfWork;
        public EmployeeController()
        {
            unitOfWork = new UnitOfWork();
        }


        public ActionResult AddEmployee()
        {
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll( new string[0]).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Address = model.Address,
                    DepartmentId = model.DepartmentId ?? null,
                    Name = model.Name,
                    Phone = model.Phone
                };
                unitOfWork.EmployeeRepository.Add(employee);
                unitOfWork.Complete();

            }
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll( new string[0]).ToList();
            return View(model);
        }
        //public ActionResult DeleteEmployee()
        //{
        //    return View();
        //}
        //public ActionResult UpdateEmployee()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult UpdateEmployee()
        //{
        //    return View();
        //}
    }
}