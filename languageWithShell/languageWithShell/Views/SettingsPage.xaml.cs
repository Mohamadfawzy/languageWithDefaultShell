using languageWithShell.Helper;
using languageWithShell.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace languageWithShell.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            await LocalizationResourceManager.SetLanguage(btn.CommandParameter.ToString());

            //var ds = DependencyService.Get<IMultipleDependencies>();
            //if (btn.CommandParameter.ToString() == "ar")
            //{
            //    ds.FlowDirectionRTL();
            //    App.Current.MainPage = new AppShell();
            //    App.Current.MainPage.FlowDirection = FlowDirection.RightToLeft;
            //}
            //else
            //{
            //    ds.FlowDirectionLTR();
            //    App.Current.MainPage = new AppShell();
            //    App.Current.MainPage.FlowDirection = FlowDirection.LeftToRight;
            //}
        }
    }
}