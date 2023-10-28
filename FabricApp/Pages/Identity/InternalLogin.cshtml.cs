using FabricAPP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FabricAPP.Pages.Identity
{
    [AllowAnonymous]
    public class InternalLoginModel : PageModel
    {
        public static User User { get; set; }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null, string provider = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(User.Login) || string.IsNullOrWhiteSpace(User.Password))
                    return Redirect("/");


                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, $"{User.Login}"),
                        new Claim(ClaimTypes.Email, "login@example.com")
                    };

                var identity = new ClaimsIdentity(claims, "MyAuthType");
                var principal = new ClaimsPrincipal(identity);


                await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   principal
                );


                return Redirect("/listofusers");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
