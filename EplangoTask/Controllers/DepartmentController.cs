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
    public class DepartmentController : Controller
    {
        private IUnitOfWork unitOfWork;
        public DepartmentController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult List()
        {
            var department = unitOfWork.DepartmentRepository.GetAll(new string[0]);
            return View(department);
        }
        public ActionResult AddDepartment()
        {
            ViewBag.AvailableManagers = unitOfWork.EmployeeRepository.Find(x => x.Department == null, new string[0]).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(CreateDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Name = model.Name,
                    ManagerId = model.ManagerId ?? default(int)
                };
                unitOfWork.DepartmentRepository.Add(department);
                unitOfWork.Complete();
            }
            ViewBag.AvailableManagers = unitOfWork.EmployeeRepository.Find(x => x.Department == null, new string[0]).ToList();
            return View(model);
        }

        public ActionResult DepartmentDetails(int id)
        {
            var department = unitOfWork.DepartmentRepository.Find(x=>x.Id == id, new[] { "Employees", "Manager"}).FirstOrDefault();
            if (department == null)
                return View("Error");
            return View(department);
        }      
        [HttpPost]
        public ActionResult RemoveEmployee(int id)
        {
            var employee = unitOfWork.EmployeeRepository.Get(id, new[] { "Employees", "Manager"});
            if (employee == null)
                return View("Error");
            int deptid = employee.DepartmentId ?? default(int);
            employee.DepartmentId = null;
            unitOfWork.Complete();
            return RedirectToAction(nameof(DepartmentDetails),new{id= deptid});
        }
        public ActionResult ChangeManager(int id)
        {
            int currentManagerId = unitOfWork.DepartmentRepository.Get(id, new string[0]).Id;
            var managers = unitOfWork.EmployeeRepository.Find(x => x.DepartmentId == null && x.Id != currentManagerId,new string[0])
                .ToList();
            return PartialView("_PartialChangeManager",managers);
        }
        [HttpPost]
        public ActionResult ChangeManager(int managerId, int id)
        {
            var dept = unitOfWork.DepartmentRepository.Get(id, new string[0]);
            dept.ManagerId = managerId;
            unitOfWork.Complete();
            return RedirectToAction(nameof(DepartmentDetails), new { id = id });
        }
        public ActionResult AddEmployee(int id)
        {
            var idsList = unitOfWork.DepartmentRepository.GetAll(new string[0]).Select(x => x.ManagerId);
           
            var employees = unitOfWork.EmployeeRepository.Find(x => x.DepartmentId == null &&!idsList.Contains(x.Id) , new string[0])
                .ToList();
            return PartialView("_PartialAddEmployee", employees);
        }
        [HttpPost]
        public ActionResult AddEmployee(int empId, int id)
        {
            var emp = unitOfWork.EmployeeRepository.Get(empId,new string[0]);
            emp.DepartmentId = id;
            unitOfWork.Complete();

            return RedirectToAction(nameof(DepartmentDetails), new { id = id });
        }

        [HttpPost]
        public ActionResult DeleteDepartment(int id)
        {
            var dept = unitOfWork.DepartmentRepository.Get(id, new string[0]);
            if (dept != null)
            {
                var employees = unitOfWork.EmployeeRepository.Find(x => x.DepartmentId == id, new string[0]).ToList();
                foreach (var employee in employees)
                {
                    employee.DepartmentId = null;
                }
                unitOfWork.Complete();
                unitOfWork.DepartmentRepository.Delete(dept);
                unitOfWork.Complete();
            }

            return RedirectToAction(nameof(List));
        }
    }
}