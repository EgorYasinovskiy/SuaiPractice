using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models.ViewModels
{
	public class SignUpViewModel
	{
		[Required(ErrorMessage = "Адрес электронной почты - обязательное поле")]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Адрес электронной почты")]
		[EmailAddress(ErrorMessage = "Введенный адрес электронной почты некорректен")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Пароль не указан")]
		[Display(Name = "Введите пароль")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "Длина пароль должна быть минимум 8 символов")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Паоль не подтвержден")]
		[Display(Name = "Подтвердите пароль")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
		public string ConfirmPassword { get; set; }

	}
}
