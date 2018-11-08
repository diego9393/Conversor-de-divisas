using System.Security.Claims;
using System.Threading.Tasks;
using SitioCore.Data;
using SitioCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SitioCore.ViewModel;

namespace SitioCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UsuarioConversor> userManager;
        private readonly SignInManager<UsuarioConversor> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<UsuarioConversor> userManager, SignInManager<UsuarioConversor> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index", "Account/Register");

                var user = new UsuarioConversor() { UserName = model.Email, Email = model.Email, FechaNacimiento = model.BirthDate };
                var result = await userManager.CreateAsync(
                    user, model.Password);

                if (!await roleManager.RoleExistsAsync("Organizer"))
                    await roleManager.CreateAsync(new IdentityRole { Name = "Organizer" });
                if (!await roleManager.RoleExistsAsync("Speaker"))
                    await roleManager.CreateAsync(new IdentityRole { Name = "Speaker" });

                await userManager.AddToRoleAsync(user, model.Role);

                /*if (result.Succeeded)
                    return View("RegistrationConfirmation");*/


                foreach (var error in result.Errors)
                    ModelState.AddModelError("error", error.Description);
                //return View(model);
                return RedirectToAction("Index", "Home/VerMonedas");
            }
            catch
            {
               return RedirectToAction("Index", "Home/Register");
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result =
                    await
                        signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                            lockoutOnFailure: false);
                if (result.Succeeded)
                    return RedirectToLocal(returnUrl);
                if (result.RequiresTwoFactor)
                {
                    //
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);

            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home/Index");
            //return View("Login");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home/VerMonedas");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}