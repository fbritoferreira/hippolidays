using System;
using Microsoft.AspNetCore.Mvc;

namespace hippolidays.ViewComponents
{
	public class CalendarViewComponent : ViewComponent
	{
		public CalendarViewComponent()
		{
			
		}
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

