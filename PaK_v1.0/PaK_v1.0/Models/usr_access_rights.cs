using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;

namespace PaK_v1._0.Models
{
    public class usr_access_rights
    {
        private PaKEntities db = new PaKEntities();

        public bool has_right(string view_path)
        {
            CustomPrincipal cPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            var views = (from v in db.wpf_views where v.view_path == view_path select v).FirstOrDefault();

            if (views == null)
                return true;

                //db.wpf_views.Where(v => v.view_path == view_path);
            views.roles.Load();
            string role = cPrincipal.Identity.Role;
            if (views.roles.Where(r => r.role_key == role).Count() > 0)
                return true;

            return false;
        }

    }
}
