using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Fragment = Android.Support.V4.App.Fragment;

namespace Jaktapp
{
    public class MapFragment : Fragment, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private SupportMapFragment _mapFragment;
        private readonly LatLng _selnes = new LatLng(63.7124, 10.0015);

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MapFragment, container, false);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            if (googleMap != null)
            {
                _map = googleMap;
            }

            UpdateMyLocationButton();

            _map.MoveCamera(CameraUpdateFactory.NewLatLngZoom(_selnes, 16));
        }

        private void CreateMapFragmentIfNeeded()
        {
            _mapFragment = ChildFragmentManager.FindFragmentByTag("MapFragment") as SupportMapFragment;

            if (_mapFragment == null)
            {
                var mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeRotateGesturesEnabled(true)
                    .InvokeCompassEnabled(true);
                
                _mapFragment = SupportMapFragment.NewInstance(mapOptions);
                var transaction = ChildFragmentManager.BeginTransaction();
                transaction.Add(Resource.Id.MapFrame, _mapFragment, "MapFragment");
                transaction.Commit();
            }
            _mapFragment.GetMapAsync(this);
        }

        private async void UpdateMyLocationButton()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                var results = new Dictionary<Permission, PermissionStatus>();
                try
                {
                    results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                }
                catch (TaskCanceledException)
                {
                    //Catches System.Threading.Tasks.TaskCanceledException: A task was canceled
                }

                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Location))
                {
                    status = results[Permission.Location];
                }
            }

            if (_map != null)
            {
                _map.MyLocationEnabled = CrossGeolocator.Current.IsGeolocationAvailable && CrossGeolocator.Current.IsGeolocationEnabled;
            }
        }

        public override void OnResume()
        {
            base.OnResume();
            CreateMapFragmentIfNeeded();
        }
    }
}