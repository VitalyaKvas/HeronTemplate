using System.ComponentModel.DataAnnotations;

namespace WebApiApplication.Models.View.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
