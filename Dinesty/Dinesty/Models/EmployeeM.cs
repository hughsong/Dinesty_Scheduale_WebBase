using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace Dinesty.Models
{
	public class EmployeeM
	{
		public Employee emp { set; get; }
		public Hashtable info = new Hashtable();

		public EmployeeM(Employee emp)
		{
			this.emp = emp;
			info.Add("MonM", emp.MonM);
			info.Add("MonN", emp.MonN);
			info.Add("WedM", emp.WesM);
			info.Add("WedN", emp.WesN);
			info.Add("ThuM", emp.ThuM);
			info.Add("ThuN", emp.ThuN);
			info.Add("FriM", emp.FriM);
			info.Add("FriN", emp.FriN);
			info.Add("SatM", emp.SatM);
			info.Add("SatN", emp.SatN);
			info.Add("SunM", emp.SunM);
			info.Add("SunN", emp.SunN);
		}

		public Boolean check(String day)
		{
			if ((bool)info[key: day])
				return true;
			else
				return false;
		}

	}

}