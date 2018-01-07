using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
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
        private DrawerLayout _drawerLayout;
        private NavigationView _leftDrawer;
        private View _drawerHeaderView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Main);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.DrawerLayout);
            _leftDrawer = FindViewById<NavigationView>(Resource.Id.LeftDrawer);

            _drawerHeaderView = _leftDrawer.GetHeaderView(0);
            var userNameText = _drawerHeaderView.FindViewById<TextView>(Resource.Id.DrawerUserNameText);
            userNameText.Text = "Halla balla";

            var toolbar = FindViewById<Toolbar>(Resource.Id.Toolbar);
            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_menu_overflow_material);

            SetSupportActionBar(toolbar);

            _leftDrawer.NavigationItemSelected += OnNavigationItemSelected;

            _loginBtn = FindViewById<Button>(Resource.Id.LoginBtn);
            _loginBtn.Click += LoginBtnClick;
            
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    _drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void OnNavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            _drawerLayout.CloseDrawers();
        }

        private void LoginBtnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MapActivity));
            StartActivity(intent);
        }
    }
}
