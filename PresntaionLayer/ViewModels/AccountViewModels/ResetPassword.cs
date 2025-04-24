using System.ComponentModel.DataAnnotations;

namespace PresntaionLayer.ViewModels.AccountViewModels
{
	public class ResetPassword
	{
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; } = string.Empty;
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = string.Empty;

	}
}
