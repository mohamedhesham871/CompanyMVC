using Microsoft.Build.Framework;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using System.ComponentModel.DataAnnotations;
namespace PresntaionLayer.ViewModels.AuthanticationViewModels
{
	public class RegisterViewModel
	{
		
	    [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "First Name is required")]
		[MaxLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
		public string FirstName { get; set; } = string.Empty;
		[MaxLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
		public string? LastName { get; set; }
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; } = string.Empty;
		[DataType(DataType.Password)]
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Password is required")]
		public string Password { get; set; } = string.Empty;
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = string.Empty;
	    public string UserName { get; set; } 
		public bool isAgree { get; set; } 

	}
}
