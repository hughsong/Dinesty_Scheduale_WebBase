using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dinesty.Models;

namespace Dinesty.Models
{
	public class FinalReport
	{
		public List<WorkDay> myWorkSchedule { set; get; }
		public Filter_Emp fe { set; get; }

		public FinalReport()
		{
			myWorkSchedule = new List<WorkDay>();
			fe = new Filter_Emp();
		}
	}

}