using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using EplangoTask.Core.DbEntities;

namespace EplangoTask.Core.DbEntitiesConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
}