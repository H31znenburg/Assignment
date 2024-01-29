using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookwormsOnline.ViewModels
{
    public class Register
    {
		[Required]
		[DataType(DataType.Text)]
		public string Firstname { get; set; }
		[Required]
		[DataType(DataType.Text)]
		public string Lastname { get; set; }
		[Required]
		[DataType(DataType.CreditCard)]
		[RegularExpression(@"^4[0-9]{15}$", ErrorMessage = "Invalid Visa Credit Card Number")]
		public string CreditCardNo{ get; set; }
		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Mobile No must be 8 digits")]
		public string MobileNo { get; set; }
		[Required]
		[DataType(DataType.Text)]
		public string BillingAddress { get; set; }
		[Required]
		[DataType(DataType.Text)]
		public string ShippingAddress { get; set; }
		[Required]
        [DataType(DataType.EmailAddress)]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Must give valid email address")]
		public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }
    }

}
