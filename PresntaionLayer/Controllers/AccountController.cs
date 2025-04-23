using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCompanyDataAccess.Model;
using PresntaionLayer.ViewModels.AuthanticationViewModels;

namespace PresntaionLayer.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager) : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel  registerView)
        {
            if(ModelState.IsValid)
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
				var result=_userManager.CreateAsync(user).Result;
                if(result.Succeeded) return RedirectToAction("LogIn");
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
    }
}
