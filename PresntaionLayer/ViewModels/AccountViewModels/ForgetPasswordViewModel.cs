using System.ComponentModel.DataAnnotations;

namespace PresntaionLayer.ViewModels.AccountViewModels
{
	public class ForgetPasswordViewModel
	{
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = null!;
	}
}
