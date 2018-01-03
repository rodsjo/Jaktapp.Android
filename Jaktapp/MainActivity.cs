using Android.App;
using Android.OS;

namespace Jaktapp
{
    [Activity(
        MainLauncher = true, 
        Name = "jaktapp.no.mainactivity",
        Label = "@string/app_name",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Main);
        }
    }
}
