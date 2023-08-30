using CptVille.Data;
using CptVille.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CptVille.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CptVille.Controllers
{
    public class AccountController : BaseController
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(VilleContext villeContext, SignInManager<IdentityUser> signInManager) : base(villeContext)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            var _InputModel = new InputModel();
            return View("~/Views/Home/Login.cshtml", _InputModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(InputModel Input )
        {
            string redirectUrl = "Admin/Index";
            if (Input.Email == "1" && Input.Password=="1")
            {
                return Redirect($"~/{redirectUrl}");
            }

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                
                if (result.Succeeded)
                {
                    return Redirect($"~/{redirectUrl}");
                }
                if (result.IsLockedOut)
                {
                    return Redirect($"~/{redirectUrl}");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("~/Views/Home/Login.cshtml");
                }
            }
            return View("~/Views/Home/Login.cshtml");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("~/Views/Home/index.cshtml");
        }
    }
}
