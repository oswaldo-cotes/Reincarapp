using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Reincarapp.Data;
using Reincarapp.Models;
using Reincarapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reincarapp.Controllers
{
    [Route("Account/[action]")]
    public partial class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration configuration;
        private readonly reincardbContext2 reincardbContext2;
        private readonly reincardbContext reincardbContext;
        private readonly IUserMigrationService userMigrationService;

        public AccountController(
            IWebHostEnvironment env,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            reincardbContext2 reincardbContext2,
            reincardbContext reincardbContext,
            IUserMigrationService userMigrationService)
        {
            this.signInManager          = signInManager;
            this.userManager            = userManager;
            this.roleManager            = roleManager;
            this.env                    = env;
            this.configuration          = configuration;
            this.reincardbContext2       = reincardbContext2;
            this.reincardbContext        = reincardbContext;
            this.userMigrationService   = userMigrationService;
        }

        private IActionResult RedirectWithError(string error, string redirectUrl = null)
        {
            if (!string.IsNullOrEmpty(redirectUrl))
            {
                return Redirect($"~/Login?error={error}&redirectUrl={Uri.EscapeDataString(redirectUrl.Replace("~", ""))}");
            }
            else
            {
                return Redirect($"~/Login?error={error}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            if (returnUrl != "/" && !string.IsNullOrEmpty(returnUrl))
            {
                return Redirect($"~/Login?redirectUrl={Uri.EscapeDataString(returnUrl)}");
            }

            return Redirect("~/Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password, string redirectUrl)
        {
            redirectUrl = string.IsNullOrEmpty(redirectUrl)
                ? "~/"
                : redirectUrl.StartsWith("/") ? redirectUrl : $"~/{redirectUrl}";

            if (env.EnvironmentName == "Development" && userName == "admin" && password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin")
                };

                roleManager.Roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Name)));
                await signInManager.SignInWithClaimsAsync(
                    new ApplicationUser { UserName = userName, Email = userName },
                    isPersistent: false,
                    claims);

                return Redirect(redirectUrl);
            }

                    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return RedirectWithError("Invalid user or password", redirectUrl);

            // Step 1 — Attempt normal sign-in against the current Identity store.
            var result = await signInManager.PasswordSignInAsync(userName, password, false, false);

            // Step 2 — If sign-in failed, attempt legacy migration and retry once.
            if (!result.Succeeded)
            {
                var migration = await userMigrationService.MigrateUserAsync(
                    userName, password, HttpContext.RequestAborted);

                if (migration.Success)
                {
                    // User was found and migrated (or was already present).
                    // Retry sign-in with the same credentials.
                    result = await signInManager.PasswordSignInAsync(userName, password, false, false);
                }
            }

            if (result.Succeeded)
                return Redirect(redirectUrl);

            return RedirectWithError("Invalid user or password", redirectUrl);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
                return BadRequest("Invalid password");

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await userManager.FindByIdAsync(id);
            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (result.Succeeded)
                return Ok();

            var message = string.Join(", ", result.Errors.Select(error => error.Description));
            return BadRequest(message);
        }

        [HttpPost]
        public ApplicationAuthenticationState CurrentUser()
        {
            return new ApplicationAuthenticationState
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                Name = User.Identity.Name,
                Claims = User.Claims.Select(c => new ApplicationClaim { Type = c.Type, Value = c.Value })
            };
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");
        }
    }
}
