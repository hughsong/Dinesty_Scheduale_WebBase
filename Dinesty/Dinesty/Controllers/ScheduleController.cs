using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dinesty.Models;
using System.Data.Entity;

namespace Dinesty.Controllers
{
    public class ScheduleController : Controller
    {
		private EmployeeContext db = new EmployeeContext();
		public static FinalReport fr = new FinalReport();

		// GET: Schedule
		public ActionResult Index()
        {
			return View(db.Employees.ToList());
        }

		public ActionResult ConfirmNum()
		{

			return View(db.WorkingDays.ToList());
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkingDay wd = db.WorkingDays.Find(id);
			if (wd == null)
			{
				return HttpNotFound();
			}
			return View(wd);
		}

		public ActionResult Generate()
		{
	
			Filter_Emp fe = new Filter_Emp(db.Employees.ToList(), db.WorkingDays.ToList());
			Filter_Emp fetmp = new Filter_Emp();
			List<WorkDay> myWorkSchedule = new List<WorkDay>();
			List<WorkDay> final = new List<WorkDay>();
			int min = 9;
			fr = new FinalReport();
				for (int a = 0; a < 20; a++)
				{
				db = new EmployeeContext();
				myWorkSchedule = new List<WorkDay>();
				fe = new Filter_Emp(db.Employees.ToList(), db.WorkingDays.ToList());
				myWorkSchedule = fe.autoArrange();
				if (min > fe.message.Count)
				{
					fetmp = fe;
					min = fe.message.Count;
					final = myWorkSchedule;

				}
					if (fe.signal == true)
					{
						final = myWorkSchedule;
						break;
					}
				}
			final.Reverse();
			fr.fe = fetmp;
			fr.myWorkSchedule = final;
			return View(fr);
		}
		public ActionResult FinalSchedule()
		{
			return View(fr);
		}

		public ActionResult test1()
		{
			return PartialView();
		}

		// POST: Employees/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "WorkingDayId,Day,Morning,Night")] WorkingDay wk)
		{
			if (ModelState.IsValid)
			{
				db.Entry(wk).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("ConfirmNum");
			}
			return View(wk);
		}
	}
}