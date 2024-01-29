using BookwormsOnline.Model;
using BookwormsOnline.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookwormsOnline.Pages
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> userManager { get; }
        private SignInManager<ApplicationUser> signInManager { get; }
       
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
		[BindProperty]
		public Register RModel { get; set; }
		public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("328bd3f5-6086-4429-85b6-60f7f4dfb0ac");
                var user = new ApplicationUser()
                {
                    FirstName = RModel.Firstname,
                    LastName = RModel.Lastname,
                    CreditCardNo = protector.Protect(RModel.CreditCardNo),
                    MobileNo = RModel.MobileNo,
                    BillingAddress = RModel.BillingAddress,
                    ShippingAddress = RModel.ShippingAddress,
                    UserName = RModel.Email,
                    Email = RModel.Email
                };
                var result = await userManager.CreateAsync(user, RModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }


    }
}
