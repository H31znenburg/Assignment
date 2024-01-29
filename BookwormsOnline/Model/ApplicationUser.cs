using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookwormsOnline.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Credit Card No is required")]
        [RegularExpression(@"^4[0-9]{15}$", ErrorMessage = "Invalid Visa Credit Card Number")]
        public string CreditCardNo { get; set; }
        [Required(ErrorMessage = "Mobile No is required")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Mobile No must be 8 digits")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Billing Address is required")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "Shipping Address is required")]
        public string ShippingAddress { get; set; }
    }
}
