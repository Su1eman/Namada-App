using Namada_Maui.Resources.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Settings
{
    public enum Theme { Default, Light, Dark, Classic }

    public static class ThemeManager
    {
        public static void SetAppTheme(Theme selectedTheme)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (selectedTheme)
                {
                    case Theme.Light:

                        mergedDictionaries.Add(new LightTheme());

                        break;
                    case Theme.Dark:

                        mergedDictionaries.Add(new DarkTheme());

                        break;
                    case Theme.Classic:

                        break;
                    default:

                        AppTheme currentTheme = Application.Current.RequestedTheme;

                        if (currentTheme == AppTheme.Dark)
                        {
                            mergedDictionaries.Add(new DarkTheme());
                        }
                        else if (currentTheme == AppTheme.Light)
                        {
                            mergedDictionaries.Add(new LightTheme());
                        }

                        break;
                }
            }
        }
    }
}