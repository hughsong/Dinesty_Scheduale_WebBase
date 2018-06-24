using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dinesty.Models
{
	public class WorkingDay
	{
		public int WorkingDayId { set; get; }
		public String Day { set; get; }
		public int Morning { set; get; }
		public int Night { set; get; }

	}
}