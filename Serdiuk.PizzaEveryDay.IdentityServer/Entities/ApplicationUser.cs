using Microsoft.AspNetCore.Identity;

namespace Serdiuk.PizzaEveryDay.IdentityServer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        { 
            FirstName = "NAme";
            LastName = "Last";
        }

        public ApplicationUser(string username) : base(username)
        {
            FirstName = "NAme";
            LastName = "Last";
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
