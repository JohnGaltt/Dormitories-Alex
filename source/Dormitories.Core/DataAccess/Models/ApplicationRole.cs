using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Dormitories.Core.DataAccess.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
