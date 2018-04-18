using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace Jaktapp
{
    public class SettingsFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.SettingsFragment, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            var versionText = view.FindViewById<TextView>(Resource.Id.VersionText);
            var version = GetAppVersion();
            versionText.Text = $"v{version}";
        }

        private static string GetAppVersion()
        {
            return Application.Context.ApplicationContext.PackageManager
                .GetPackageInfo(Application.Context.ApplicationContext.PackageName, 0).VersionName;
        }
    }
}