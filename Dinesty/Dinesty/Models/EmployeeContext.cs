using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dinesty.Models
{
	public class EmployeeContext:DbContext
	{
		public DbSet<Employee> Employees { set; get; }
		public DbSet<WorkingDay> WorkingDays { set; get; }

	}
}