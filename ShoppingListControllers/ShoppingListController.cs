using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.DataBase;
using ShoppingList.Domain;
using ShoppingList.Domain.Abstractions;
using ShoppingList.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingList.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	public class ShoppingListController : Controller
	{
		IShoppingService shoppingService;
		DataContext db;
		public ShoppingListController(DataContext context, IShoppingService shoppingService)
		{
			this.db = context;
			this.shoppingService = shoppingService;
			shoppingService.InitializeDatabase();
		}
		
		[HttpGet]
		public IEnumerable<Purchase> Get()
		{
			return shoppingService.GetPurchases();
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var list = shoppingService.GetPurchaseById(id);
			if (list == null)
				return NotFound();
			return new ObjectResult(list);
		}

		[HttpPost]
		public IActionResult Post([FromBody]Purchase list)
		{
			if (list == null)
			{
				return BadRequest();
			}
			shoppingService.PostPurchase(list);
			return Ok(list);
		}

		[HttpPut("{id}")]
		public IActionResult Put([FromBody]Purchase list)
		{
			if (list == null)
			{
				return BadRequest();
			}
			if (!db.Purchases.Any(x => x.Id == list.Id))
			{
				return NotFound();
			}
			shoppingService.PutPurchase(list);
			return Ok(list);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Purchase purchase = shoppingService.FindPurchase(id);
			if (purchase == null)
			{
				return NotFound();
			}
			shoppingService.DeletePurchaseById(purchase, id);
			return Ok(purchase);
		}
	}
}
