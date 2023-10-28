using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FabricAPP.Pages.Identity
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        public IActionResult OnGetAsync(string returnUrl = null, string provider = "")
        {
            try
            {
                var authenticationProperties = new AuthenticationProperties
                {
                    RedirectUri = Url.Page("./ExternalLogin",
                   pageHandler: "Callback",
                   values: new { returnUrl })
                };
                return new ChallengeResult(provider, authenticationProperties);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            try
            {
                var user = this.User.Identities.FirstOrDefault();


                if (user.IsAuthenticated)
                {
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        RedirectUri = this.Request.Host.Value
                    };
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(user),
                    authProperties);
                    return LocalRedirect("/listofusers");
                }

                return LocalRedirect("/");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
