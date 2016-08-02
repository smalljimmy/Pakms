using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaK_v1._0.Models
{
    class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity() : base(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        { }
    }
}
