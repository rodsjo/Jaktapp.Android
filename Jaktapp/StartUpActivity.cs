using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Support.V7.App;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Jaktapp
{
    [Activity(
        MainLauncher = true,
        NoHistory = true,
        Name = "jaktapp.no.startupactivity",
        Label = "@string/app_name",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class StartUpActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            //Initialize user dialogs
            UserDialogs.Init(this);

            //Initialize app center
            AppCenter.Start("d94d14eb-eb5d-4a1a-b086-4d306ad727f9", typeof(Analytics), typeof(Crashes));


            StartApp();
        }

        private void StartApp()
        {
            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
            Finish();
        }
    }
}
