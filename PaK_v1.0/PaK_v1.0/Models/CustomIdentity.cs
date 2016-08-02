//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Security.Principal;
namespace PaK_v1._0.Models
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name, string email, string role, string theme, string fontsize, string color)
        {
            Name = name;
            Email = email;
            Role = role;
            Theme = theme;
            Fontsize = fontsize;
            Color = color;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public string Theme { get; set; }
        public string Fontsize { get; set; }
        public string Color { get; set; }

        #region IIdentity Members
        public string AuthenticationType { get { return "Custom authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
        #endregion
    }
}
