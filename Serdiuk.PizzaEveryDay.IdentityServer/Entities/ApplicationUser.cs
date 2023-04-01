using Microsoft.AspNetCore.Identity;

namespace Serdiuk.PizzaEveryDay.IdentityServer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        public ApplicationUser(string username) : base(username)
        {

        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
