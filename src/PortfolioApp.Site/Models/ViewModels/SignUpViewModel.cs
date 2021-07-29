using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models.ViewModels
{
	public class SignUpViewModel
	{
		[Required]
		[Display(Name = "Адресс электронной почты")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Введите пароль")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "Длина пароль должна быть минимум 8 символов")]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Подтвердите пароль")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
		public string ConfirmPassword { get; set; }

	}
}
