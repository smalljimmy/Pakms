using FirstFloor.ModernUI.Presentation;
using PaK_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaK_v1._0.utilities
{
    static class ThemeManager
    {
        internal static void SaveTheme(Models.CustomIdentity customIdentity)
        {
            try
            {
                using (PaKEntities db = new PaKEntities())
                {
                    users user = db.users.Single(x => x.usr_name == customIdentity.Name);
                    user.theme = customIdentity.Theme;
                    user.fontsize = customIdentity.Fontsize;
                    user.color = customIdentity.Color;

                    db.SaveChanges();
                }
            }
            catch { };
        }

        internal static void LoadTheme(Models.CustomIdentity customIdentity)
        {
            try
            {
                AppearanceManager.Current.AccentColor = (Color)ColorConverter.ConvertFromString(customIdentity.Color);
                AppearanceManager.Current.FontSize = (customIdentity.Fontsize.ToString() == "large") ? FontSize.Large : FontSize.Small;
                AppearanceManager.Current.ThemeSource = new System.Uri(customIdentity.Theme, UriKind.Relative);
            }
            catch { };
        }
    
    }
}
