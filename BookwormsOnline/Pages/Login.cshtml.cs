using BookwormsOnline.Model;
using BookwormsOnline.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace BookwormsOnline.Pages
{
    public class LoginModel : PageModel
    {
		[BindProperty]
		public Login LModel { get; set; }

		private readonly SignInManager<ApplicationUser> signInManager;
        public LoginModel(SignInManager<ApplicationUser> signInManager)
		{
			this.signInManager = signInManager;
		}
		public void OnGet()
        {
        }
		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				var identityResult = await signInManager.PasswordSignInAsync(LModel.Email, LModel.Password,
				LModel.RememberMe, lockoutOnFailure: true);
				if (identityResult.Succeeded)
				{
					var claims = new List<Claim> {
						new Claim(ClaimTypes.Name, "c@c.com"),
						new Claim(ClaimTypes.Email, "c@c.com"),


                        //new Claim("Department" , "HR")
                    };

					var i = new ClaimsIdentity(claims, "MyCookieAuth");
					ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(i);
					await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
					
					return RedirectToPage("Index");
				}
				if (identityResult.IsLockedOut)
				{
					ModelState.AddModelError("", "Your account has been locked out for 30 seconds due to multiple failed login attempts.");
					return Page();
				}
				else
				{
					ModelState.AddModelError("", "Invalid login attempt.");
				}

				ModelState.AddModelError("", "Username or Password incorrect");
			}
			return Page();
		}
	}
}
