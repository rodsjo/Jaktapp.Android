using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace Jaktapp
{
    [Activity(
        MainLauncher = true,
        NoHistory = true,
        Name = "jaktapp.no.mainactivity",
        Label = "@string/app_name",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            //TODO: Setup, initialize app

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
