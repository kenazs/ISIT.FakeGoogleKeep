using Microsoft.AspNetCore.Identity;

namespace ISIT.FakeGoogleKeep.Models
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }

        public IdentityUser[] Everyone { get; set; }
    }
}
