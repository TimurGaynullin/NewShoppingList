﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingList.Controllers.ViewModels
{
	public class RegisterModel
	{
		[Required(ErrorMessage = "Не указан Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Не указан Login")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Пароль введен неверно")]
		public string ConfirmPassword { get; set; }
	}
}
