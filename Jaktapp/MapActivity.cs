using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace Jaktapp
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MapActivity);
        }
    }
}