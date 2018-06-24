using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dinesty.Models
{
	public class Employee
	{
		public int EmployeeId { set; get; }
		public String Name { set; get; }
		public int Times { set; get; }
		public int Proficiency { set; get; }
		public String Level { set; get; }
		public Boolean MonM { set; get; }
		public Boolean MonN { set; get; }
		public Boolean WesM { set; get; }
		public Boolean WesN { set; get; }
		public Boolean ThuM { set; get; }
		public Boolean ThuN { set; get; }
		public Boolean FriM { set; get; }
		public Boolean FriN { set; get; }
		public Boolean SatM { set; get; }
		public Boolean SatN { set; get; }
		public Boolean SunM { set; get; }
		public Boolean SunN { set; get; }

	}
}