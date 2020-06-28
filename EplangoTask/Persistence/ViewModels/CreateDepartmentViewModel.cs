using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EplangoTask.Persistence.ViewModels
{
    public class CreateDepartmentViewModel
    {
        [Required(ErrorMessage = "اسم القسم مطلوب")]
        public string Name { get; set; }
        [Required(ErrorMessage = "القسم لابد ان يكون له مدير")]
        public int? ManagerId { get; set; }
    }
}