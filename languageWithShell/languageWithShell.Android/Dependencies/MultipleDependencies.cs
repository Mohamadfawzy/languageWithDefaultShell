using Android.App;
using Android.Views;
using languageWithShell.Droid.Dependencies;
using languageWithShell.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(MultipleDependencies))]

namespace languageWithShell.Droid.Dependencies
{
    public class MultipleDependencies : IMultipleDependencies
    {
        Activity activity = (Activity)MainActivity.Instance;

        public void FlowDirectionLTR()
        {
            activity.Window.DecorView.LayoutDirection = LayoutDirection.Ltr;
        }

        public void FlowDirectionRTL()
        {
            activity.Window.DecorView.LayoutDirection = LayoutDirection.Rtl;
        }
    }
}