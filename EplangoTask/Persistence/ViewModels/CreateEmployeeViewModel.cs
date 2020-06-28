using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EplangoTask.Persistence.ViewModels
{
    public class CreateEmployeeViewModel
    {

        [Required(ErrorMessage = "هاتف الموظف مطلوب")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "اسم الموظف مطلوب")]
        public string Name { get; set; }
        [Required(ErrorMessage = "عنوان الموظف مطلوب")]
        public string Address { get; set; }

        public int? DepartmentId { get; set; }
    }
}