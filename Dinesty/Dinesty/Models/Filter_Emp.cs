using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dinesty.Models;

namespace Dinesty.Models

{
	public class Filter_Emp
	{
		private Random numGenerator = new Random();
		private List<EmployeeM> myEmp = new List<EmployeeM>();
		private List<WorkDay> work = new List<WorkDay>();
		private List<WorkingDay> wd;
		public List<String> message;
		public Boolean signal { get; set; } = false;
		public List<String> Warningdays { get; set; }
		public EmployeeM Casher { get; set; }=null;
		public EmployeeM Usher { get; set; } = null;
		public Filter_Emp(List<Employee> emp, List<WorkingDay> wd)
		{
			List<Employee> tmpEmp = new List<Employee>();
			tmpEmp.AddRange(emp);
			this.wd = wd;
			signal = true;
			Warningdays = new List<String>();
			message = new List<string>();

			foreach (var a in tmpEmp)
			{
				myEmp.Add(new EmployeeM(a));
			}
		}

		public Filter_Emp()
		{

		}

		public List<EmployeeM> findAvalibleEmp(List<EmployeeM> emplopyees, String day)
		{
			List<EmployeeM> tmp = new List<EmployeeM>();
			foreach (var emp in emplopyees)
			{
				if (emp.check(day) && emp.emp.Times>0)
				{
					tmp.Add(emp);
					Console.WriteLine(day + ": " + emp.emp.Name);
				}
			}
			return tmp;
		}

		public EmployeeM findCasher(List<EmployeeM> emp, String day)
		{
			List<EmployeeM> tmp = new List<EmployeeM>();
			foreach (var a in emp)
			{
				if (a.emp.Level.ToLower().Equals("a") || a.emp.Level.ToLower().Equals("b"))
					tmp.Add(a);
			}

			if (tmp.Count == 0)
			{
				foreach (var a in emp)
				{
					if (a.emp.Level.ToLower().Equals("s"))
						tmp.Add(a);
				}
			}

			if (tmp.Count > 1)
			{
				int index = numGenerator.Next(tmp.Count);
				myEmp[myEmp.IndexOf(tmp[index])].emp.Times--;
				return tmp[index];
			}
			else if (tmp.Count == 1)
			{
				myEmp[myEmp.IndexOf(tmp[0])].emp.Times--;
				return tmp[0];
			}
			else
			{
				message.Add(String.Format("There is no avalible colleague for Casher on {0}\n Please try to Generate again \nOr Review working schedule and Modify employee info", day));
				return null;
			}
		}

		public EmployeeM findUsher(List<EmployeeM> emp, String day)
		{
			List<EmployeeM> tmp = new List<EmployeeM>();

			foreach (var a in emp)
			{
				if (a.emp.Level.ToLower().Equals("s") || a.emp.Level.ToLower().Equals("a") || a.emp.Level.ToLower().Equals("c"))
				{
					tmp.Add(a);
				}
			}

			if (tmp.Count > 1)
			{
				int index = numGenerator.Next(tmp.Count);
				myEmp[myEmp.IndexOf(tmp[index])].emp.Times--;
				return tmp[index];
			}
			else if (tmp.Count == 1)
			{
				myEmp[myEmp.IndexOf(tmp[0])].emp.Times--;
				return tmp[0];
			}
			else
			{
				message.Add(String.Format("There is no avalible colleague for Usher on {0}.", day));
				return null;
			}
		}

		public EmployeeM findMoti(List<EmployeeM> emp, int num, String day)
		{
			List<EmployeeM> tmp = new List<EmployeeM>();

			foreach (var a in emp)
			{
				if (a.emp.Level.ToLower().Equals("s"))
				{
					myEmp[myEmp.IndexOf(a)].emp.Times--;
					return a;
				}
				if (a.emp.Proficiency >= num)
				{
					tmp.Add(a);
				}
			}

			if (tmp.Count > 1)
			{
				int index = numGenerator.Next(tmp.Count);
				myEmp[myEmp.IndexOf(tmp[index])].emp.Times--;
				return tmp[index];
			}
			else if (tmp.Count == 1)
			{
				myEmp[myEmp.IndexOf(tmp[0])].emp.Times--;
				return tmp[0];
			}
			else
			{
				message.Add(String.Format("There is no avalible colleague for Moti on {0}.", day));
				return null;
			}
		}


		public EmployeeM findOrder(List<EmployeeM> emp, String day)
		{
			List<EmployeeM> tmp = new List<EmployeeM>();
			foreach (var a in emp)
			{
				if (a.emp.Proficiency >= 40)
				{
					tmp.Add(a);
				}
			}

			if (tmp.Count > 1)
			{
				int index = numGenerator.Next(tmp.Count);
				myEmp[myEmp.IndexOf(tmp[index])].emp.Times--;
				return tmp[index];
			}
			else if (tmp.Count == 1)
			{
				myEmp[myEmp.IndexOf(tmp[0])].emp.Times--;
				return tmp[0];
			}
			else
			{
				message.Add(String.Format("There is no avalible colleague to order on {0}.", day));
				return null; 
			}
		}

		public EmployeeM findDeli(List<EmployeeM> emp, String day)
		{
			List<EmployeeM> tmp = new List<EmployeeM>();
			foreach (var a in emp)
			{
				if (a.emp.Proficiency >= 30)
				{
					tmp.Add(a);
				}
			}

			if (tmp.Count > 1)
			{
				int index = numGenerator.Next(tmp.Count);
				myEmp[myEmp.IndexOf(tmp[index])].emp.Times--;
				return tmp[index];
			}
			else if (tmp.Count == 1)
			{
				myEmp[myEmp.IndexOf(tmp[0])].emp.Times--;
				return tmp[0];
			}
			else
			{
				message.Add(String.Format("There is no avalible colleague to busperson on {0}.", day));
				return null;
			}
		}

		public EmployeeM findTB(List<EmployeeM> emp, String day)
		{
			if (emp.Count > 0)
			{
				int index = numGenerator.Next(emp.Count);
				myEmp[myEmp.IndexOf(emp[index])].emp.Times--;
				return emp[index];
			}
			else
			{
				message.Add(String.Format("There is no avalible colleague for table on {0}.", day));
				return null;
			}
			

		}

		public void filter(String day, int num)
		{
			List<EmployeeM> tmp = new List<EmployeeM>();
			Boolean flag = true;
			WorkDay tmp2 = new WorkDay(day, num);
			tmp = findAvalibleEmp(myEmp, day);
			EmployeeM empNow = null; 
			if (day.Contains("N"))
			{
				empNow = findCasher(tmp, day);
				if (empNow != null)
				{
					tmp2.addEmp(empNow.emp.Name, "$");
					tmp.Remove(empNow);
					Casher = empNow;
				}
				else
				{
					flag = false;
				}
				empNow = findUsher(tmp, day);
				if (empNow != null)
				{
					tmp2.addEmp(empNow.emp.Name, "^");
					tmp.Remove(empNow);
					Usher = empNow;
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				if (tmp.Contains(Casher))
				{
					tmp2.addEmp(Casher.emp.Name, "$");
					tmp.Remove(Casher);
				}
				else
				{
				    empNow = findCasher(tmp, day);
					if (empNow != null)
					{
						tmp2.addEmp(empNow.emp.Name, "$");
						tmp.Remove(empNow);
					}
					else
					{
						flag = false;
					}
				}

				if (tmp.Contains(Usher))
				{
					tmp2.addEmp(Usher.emp.Name, "^");
					tmp.Remove(Usher);
				}
				else
				{
					empNow = findUsher(tmp, day);
					if (empNow != null)
					{
						tmp2.addEmp(empNow.emp.Name, "^");
						tmp.Remove(empNow);
						Usher = empNow;
					}
					else
					{
						flag = false;
					}
				}
			}

			if (num == 6)
			{
				empNow = findMoti(tmp, 60, day);
				if (empNow != null)
				{
					tmp2.addEmp(empNow.emp.Name, "*");
					tmp.Remove(empNow);
				}
				else
				{
					flag = false;
				}
			}
			else if (num == 7)
			{
				empNow = findMoti(tmp, 60,day);
				if (empNow != null)
				{
					tmp2.addEmp(empNow.emp.Name, "*D");
					tmp.Remove(empNow);
				}
				else
				{
					flag = false;
				}
				empNow = findMoti(tmp, 60, day);
				if(empNow != null)
				{
					tmp2.addEmp(empNow.emp.Name, "*T");
					tmp.Remove(empNow);
				}
				else
				{
					flag = false;
				}
			}
			else if (num == 8)
			{
				empNow = findMoti(tmp, 70, day);
				if (empNow != null)
				{
					tmp2.addEmp(empNow.emp.Name, "*");
					tmp.Remove(empNow);
				}
				else
				{
					flag = false;
				}

				empNow = findMoti(tmp, 60, day);
				if (empNow != null)
				{
					tmp2.addEmp(empNow.emp.Name, "*D");
					tmp.Remove(empNow);
				}
				else
				{
					flag = false;
				}
				empNow = findMoti(tmp, 60, day);
				if (empNow != null)
				{
					tmp2.addEmp(empNow.emp.Name, "*T");
					tmp.Remove(empNow);
				}
				else
				{
					flag = false;
				}
			}

			empNow = findOrder(tmp, day);
			if (empNow != null)
			{
				tmp2.addEmp(empNow.emp.Name, "O");
				tmp.Remove(empNow);
			}
			else
			{
				flag = false;
			}

			empNow = findDeli(tmp, day);
			if (empNow != null)
			{
				tmp2.addEmp(empNow.emp.Name, "D");
				tmp.Remove(empNow);
			}
			else
			{
				flag = false;
			}

			empNow = findTB(tmp, day);
			if (empNow != null)
			{
				tmp2.addEmp(empNow.emp.Name, "T");
				tmp.Remove(empNow);
			}
			else
			{
				flag = false;
			}


			work.Add(tmp2);
			if (flag == false)
			{
				Warningdays.Add(day);
				signal = false;
			}
		}

		public List<WorkDay> autoArrange()
		{
			filter("SunN", wd[5].Night);
			filter("SunM", wd[5].Morning);
			filter("SatN", wd[4].Night);
			filter("SatM", wd[4].Morning);
			filter("FriN", wd[3].Night);
			filter("FriM", wd[3].Morning);
			filter("ThuN", wd[2].Night);
			filter("ThuM", wd[2].Morning);
			filter("WedN", wd[1].Night);
			filter("WedM", wd[1].Morning);
			filter("MonN", wd[0].Night);
			filter("MonM", wd[0].Morning);
			return work;
		}

	}
}