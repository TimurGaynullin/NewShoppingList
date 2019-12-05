using Microsoft.AspNetCore.Mvc;
using ShoppingList.DataBase;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList.Controllers
{
	[Route("api/[controller]")]
	public class TimeController : Controller
	{
		DataContext db;
		public TimeController(DataContext context)
		{
			this.db = context;
		}

		[HttpGet("{id}")]
		public IActionResult Get(DateTime dateTimeStart, DateTime dateTimeFinish)
		{
			IEnumerable<Purchase> list = db.Purchases.ToList<Purchase>();
			list = list.Where(x => x.TimeOfNotation.Date >= dateTimeStart.Date && x.TimeOfNotation.Date <= dateTimeFinish.Date);
			if (list == null)
				return NotFound();
			return new ObjectResult(list);
		}
	}
}
