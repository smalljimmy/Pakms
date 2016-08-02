using System.Linq;
using System.Security.Principal;


namespace PaK_v1._0.Models
{
    class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _identity;

        public CustomIdentity Identity
        {
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }

        #region IPrincipal Members
        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return _identity.Role.Contains(role);
        }

        //public string Role()
        //{
        //    return _identity.Role;
        //}
        #endregion

    }
}
