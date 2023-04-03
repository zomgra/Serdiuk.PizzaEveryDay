using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Serdiuk.PizzaEveryDay.IdentityServer.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ReturnUrl { get; set; }

    }
}
