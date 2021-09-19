using languageWithShell.Interface;
using languageWithShell.Resources.Languages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace languageWithShell.Helper
{
    public static class LocalizationResourceManager
    {
        private static string languageCurrentDevice = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        public static string CurrentLanguage
        {
            get => Preferences.Get(nameof(CurrentLanguage), languageCurrentDevice);
            set => Preferences.Set(nameof(CurrentLanguage), value);
        }

        public static async Task<bool> SetLanguage(string langName = null)
        {
            if (langName == null)
                langName = CurrentLanguage;
            CultureInfo language = new CultureInfo(langName);
            Thread.CurrentThread.CurrentUICulture = language;
            LanguageResources.Culture = language;
            var result = ChangeDirection(language.ToString());
            return await Task.FromResult(result);
        }

        private static bool ChangeDirection(string name)
        {
            var ds = DependencyService.Get<IMultipleDependencies>();
            if (name == "ar")
            {
                ds.FlowDirectionRTL();
                App.Current.MainPage = new AppShell();
                App.Current.MainPage.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                ds.FlowDirectionLTR();
                App.Current.MainPage = new AppShell();
                App.Current.MainPage.FlowDirection = FlowDirection.LeftToRight;
            }
            CurrentLanguage = name;
            return true;
        }
    }
}
