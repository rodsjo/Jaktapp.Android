using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Jaktapp
{
    [Activity(
        Label = "Login",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : AppCompatActivity
    {
        private Button _loginBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            //TODO: Get username from local storage

            var toolbar = FindViewById<Toolbar>(Resource.Id.LoginToolbar);
            toolbar.Title = "Logg inn";
            SetSupportActionBar(toolbar);

            _loginBtn = FindViewById<Button>(Resource.Id.LoginBtn);
            _loginBtn.Click += LoginBtnClick;
        }

        private void LoginBtnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MapActivity));
            StartActivity(intent);

            //TODO: Call Finish() if successful login
            Finish();
        }
    }
}