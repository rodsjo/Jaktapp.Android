﻿using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace Jaktapp
{
    public class HistoryFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.HistoryFragment, container, false);
        }
    }
}