using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.PizzaEveryDay.IdentityServer.Entities;
using Serdiuk.PizzaEveryDay.IdentityServer.Models;
using System.Security.Claims;

namespace Serdiuk.PizzaEveryDay.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            var model = new LoginViewModel()
            {
                ExternalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync(),
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        public async Task<IActionResult> ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Auth", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("RegisterExternal", new ExternalLoginViewModel
            {
                ReturnUrl = returnUrl,
                UserName = info.Principal.FindFirstValue(ClaimTypes.Name)
            });
        }
        [AllowAnonymous]
        public IActionResult RegisterExternal(ExternalLoginViewModel model)
        {
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("RegisterExternal")]
        public async Task<IActionResult> RegisterExternalConfirmed(ExternalLoginViewModel model)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }

            var user = new ApplicationUser(model.UserName);

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                var identityResult = await _userManager.AddLoginAsync(user, info);
                if (identityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ExternalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                model.ExternalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            model.ExternalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();
            return View(model);
        }
    }
}
