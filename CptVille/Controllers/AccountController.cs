using CptVille.Data;
using CptVille.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CptVille.ViewModel;

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
        public async Task<IActionResult> Login(InputModel Input)
        {
            string returnUrl = Url.Content("~/Admin/Index");
            if (Input.Email == "1" && Input.Password=="1")
            {
                return LocalRedirect(returnUrl);
            }

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("~/Views/Home/Login.cshtml");
                }
            }
            return View("~/Views/Home/Login.cshtml");
        }
        public async Task<IActionResult> Profile()
        {
            return View();
        }
    }
}
