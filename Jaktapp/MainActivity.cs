using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Jaktapp
{
    [Activity(
        MainLauncher = true, 
        Name = "jaktapp.no.mainactivity",
        Label = "@string/app_name",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private Button _loginBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Hei sexy";

            _loginBtn = FindViewById<Button>(Resource.Id.LoginBtn);
            _loginBtn.Click += LoginBtnClick;
        }

        private void LoginBtnClick(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(MapActivity));
            StartActivity(intent);
        }
    }
}
