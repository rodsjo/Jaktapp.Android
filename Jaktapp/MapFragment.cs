using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
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
            CreateMapFragmentIfNeeded();
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
            _map.MyLocationEnabled = true;
            _map.MoveCamera(CameraUpdateFactory.NewLatLngZoom(_selnes, 16));
        }

        private void CreateMapFragmentIfNeeded()
        {
            if (_map != null)
            {
                return;
            }
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
                transaction.Add(Resource.Id.map_frame, _mapFragment, "MapFragment");
                transaction.Commit();
            }
            _mapFragment.GetMapAsync(this);
        }

        public override void OnResume()
        {
            base.OnResume();
            CreateMapFragmentIfNeeded();
        }
    }
}