using System.ComponentModel.DataAnnotations;

namespace Serdiuk.PizzaEveryDay.IdentityServer.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ReturnUrl { get; set; }
    }
}
