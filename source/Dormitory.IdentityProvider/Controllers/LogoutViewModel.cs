using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitory.IdentityProvider.Controllers
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; }
    }

    public class LogoutInputModel
    {
        public string LogoutId { get; set; }
    }
}
