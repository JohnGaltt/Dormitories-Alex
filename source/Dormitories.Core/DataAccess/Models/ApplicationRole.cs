using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Dormitories.Core.DataAccess.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole(string name)
        {
            Name = name;
            NormalizedName = name.ToUpper();
        }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
