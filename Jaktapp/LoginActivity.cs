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
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : AppCompatActivity
    {
        private Button _loginBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            var toolbar = FindViewById<Toolbar>(Resource.Id.LoginToolbar);
            SetSupportActionBar(toolbar);

            _loginBtn = FindViewById<Button>(Resource.Id.LoginBtn);
            _loginBtn.Click += LoginBtnClick;
        }

        private void LoginBtnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);

            Finish();
        }
    }
}