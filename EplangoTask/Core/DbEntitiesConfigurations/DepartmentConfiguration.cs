using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using EplangoTask.Core.DbEntities;

namespace EplangoTask.Core.DbEntitiesConfigurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            HasKey(c => c.Id);
            HasMany(n => n.Employees).WithOptional(c => c.Department)
                .HasForeignKey(c=>c.DepartmentId).WillCascadeOnDelete(false);

            HasRequired(n => n.Manager).WithMany(c=>c.DepartmentsManagement)
                .HasForeignKey(c=>c.ManagerId).WillCascadeOnDelete(false);
        }

        
    }
}