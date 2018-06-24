using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dinesty.Models
{
	public class WorkDay
	{
		public String day { get; set; }
		public int num { get; set; }
		public String shift { get; set; }
		public List<String> emp { get; set; }

		public WorkDay(String d, int num)
		{
			this.day = d;
			this.num = num;
			emp = new List<string>();
		}

		public void addEmp(String name, String position)
		{
			emp.Add(name + "  " + position);
		}

	}
}