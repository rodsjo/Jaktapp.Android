using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Plugin.Permissions;
using Fragment = Android.Support.V4.App.Fragment;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Jaktapp
{
    [Activity(
        Label = "Map", 
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout _drawerLayout;
        private NavigationView _leftDrawer;
        private View _drawerHeaderView;
        private Dictionary<string, Fragment> _fragments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainActivity);

            _fragments = new Dictionary<string, Fragment>
            {
                {"map", new MapFragment()},
                {"create", new CreateHuntFragment()},
                {"friends", new FriendsFragment()},
                {"history", new HistoryFragment()},
                {"settings", new SettingsFragment()},
            };

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.DrawerLayout);
            _leftDrawer = FindViewById<NavigationView>(Resource.Id.LeftDrawer);

            _drawerHeaderView = _leftDrawer.GetHeaderView(0);
            var userNameText = _drawerHeaderView.FindViewById<TextView>(Resource.Id.DrawerUserNameText);
            userNameText.Text = "Stig Rune Sollie";

            var toolbar = FindViewById<Toolbar>(Resource.Id.MainToolbar);
            toolbar.SetNavigationIcon(Resource.Drawable.ic_menu_white);

            SetSupportActionBar(toolbar);

            _leftDrawer.NavigationItemSelected += OnNavigationItemSelected;

            //If first time you will want to go ahead and click first item
            if (savedInstanceState == null)
            {
                MenuItemClicked("map");
            }
        }

        private void MenuItemClicked(string tag)
        {
            var fragment = _fragments[tag];

            if (SupportFragmentManager.FindFragmentByTag(tag) == null)
            {
                //Create it
                SupportFragmentManager.BeginTransaction().Add(Resource.Id.FragmentFrame, fragment, tag).Commit();
            }

            //Show it
            SupportFragmentManager.BeginTransaction().Show(fragment).Commit();

            //Hide the other fragments
            foreach (var frag in _fragments)
            {
                if (frag.Key != tag)
                {
                    SupportFragmentManager.BeginTransaction().Hide(frag.Value).Commit();
                }
            }
            SetToolbarTitle(tag);
        }

        private void SetToolbarTitle(string tag)
        {
            switch (tag)
            {
                case "map":
                    SupportActionBar.Title = "Kart";
                    break;
                case "create":
                    SupportActionBar.Title = "Ny jakt";
                    break;
                case "friends":
                    SupportActionBar.Title = "Venner";
                    break;
                case "history":
                    SupportActionBar.Title = "Historikk";
                    break;
                case "settings":
                    SupportActionBar.Title = "Innstillinger";
                    break;
            }
        }

        private void OnNavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.main_menu_item_map:
                    MenuItemClicked("map");
                    break;
                case Resource.Id.main_menu_item_create_hunt:
                    MenuItemClicked("create");
                    break;
                case Resource.Id.main_menu_item_friends:
                    MenuItemClicked("friends");
                    break;
                case Resource.Id.main_menu_item_history:
                    MenuItemClicked("history");
                    break;
                case Resource.Id.main_menu_item_settings:
                    MenuItemClicked("settings");
                    break;
            }
            _drawerLayout.CloseDrawers();
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}