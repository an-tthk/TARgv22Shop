using System.ComponentModel.DataAnnotations;

namespace TARgv22Shop.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
