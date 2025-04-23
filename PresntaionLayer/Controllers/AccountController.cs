using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCompanyDataAccess.Model;
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
    }
}
