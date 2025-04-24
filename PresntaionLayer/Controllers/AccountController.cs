using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCompanyDataAccess.Model;
using PresntaionLayer.Helper;
using PresntaionLayer.ViewModels.AccountViewModels;
using PresntaionLayer.ViewModels.AuthanticationViewModels;

namespace PresntaionLayer.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager) : Controller
    {

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerView)
        {
            if (ModelState.IsValid)
            {
                // want to call Service UserManager Found it in Package
                // so will make Injection 		
                var user = new ApplicationUser()
                {
                    FirstName = registerView.FirstName,
                    LastName = registerView.LastName,
                    UserName = registerView.UserName,
                    Email = registerView.Email,
                    //there is no need to add password here
                };
                // we can add the password here
                var result = _userManager.CreateAsync(user, registerView.Password).Result;
                if (result.Succeeded) return RedirectToAction("LogIn");
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(registerView);
        }
        #endregion

        #region Log In
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LogInViewModel logInViewModel)
        {
            if (ModelState.IsValid)
            {
                //1-Cheack on Email
                //2-Cheack on Password
                var user = _userManager.FindByEmailAsync(logInViewModel.Email).Result;
                if (user is null) ModelState.AddModelError("", "Invalid Login ");
                else
                {

                    var getpass = _userManager.CheckPasswordAsync(user, logInViewModel.Password).Result;

                    if (getpass)
                    {
                        var res = _signInManager.PasswordSignInAsync(user, logInViewModel.Password, logInViewModel.IsRemember, false).Result;
                        if (res.Succeeded) return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Invalid Login");
                }
            }
            return View(logInViewModel);
        }
        #endregion

        #region LogOut
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "Account");
        }
        #endregion
        #region ForgetPasssword
        [HttpGet]
        public IActionResult ForgetPassword()
		{
			return View();
		}
        #endregion
        #region SendResetPassword
        [HttpPost]
        public IActionResult SendResetPassword(ForgetPasswordViewModel forgetPassword)
        {
            if(ModelState.IsValid)
            {
                var res = _userManager.FindByEmailAsync(forgetPassword.Email).Result;

                if(res is not null)
                {
					//Generate Token
                    var token = _userManager.GeneratePasswordResetTokenAsync(res).Result;
					//create Url 
					var url = Url.Action("ResetPassword", "Account", new { email = res.Email,token }, Request.Scheme);
					//create Email
                    var email= new Email()
					{
						To = res.Email,
						Subject = "Reset Password",
						Body = url
                    };

					//Send Email
					bool isEmailSent =EmailSettings.SendEmail(email);
                    if (isEmailSent) { return RedirectToAction("CheckYourInbox"); }
					else
					{
						ModelState.AddModelError("", "Error Happen Try Again");
					}
				}
                ModelState.AddModelError("", "Error Happen Try Again");
			}

            return View("ForgetPassword");
        }

        #endregion
        public IActionResult CheckYourInbox()
        {
            return View();
        }

        #region ResetPassword
        [HttpGet]
        public IActionResult ResetPassword(string Email,string Token)
        {
            TempData["Email"] = Email;
            TempData["Token"] = Token;
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            if(ModelState.IsValid)
            {
                var emil = TempData["Email"] as string;
                var Token = TempData["Token"] as string;

                if (emil is null || Token is null) return BadRequest();
                var user = _userManager.FindByEmailAsync(emil).Result;
                if(user is not null)
                {
                    var reset = _userManager.ResetPasswordAsync(user, Token, resetPassword.Password).Result;
                    if (reset.Succeeded) 
                        return RedirectToAction("LogIn");

					else
                    {
                        ModelState.AddModelError("", "Error Try Again");
                    }
                }
            }
            return View(resetPassword);
        }
		#endregion
	}
}
