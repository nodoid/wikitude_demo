using System;
using Android.App;
using Android.OS;
using Android.Util;
using Wikitude.Architect;
using Android.Content.PM;
using Android.Views;

namespace wikitude_demo.Droid
{
    [Activity(ScreenOrientation = ScreenOrientation.Landscape)]
    public class WikitudeActivity : Activity
    {
        protected ArchitectView architectView;

        const string SAMPLE_WORLD_URL = "samples/1_Client$Recognition_1_Image$On$Target/index.html";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.sample_cam);
            //Title = TITLE;

            architectView = FindViewById<ArchitectView>(Resource.Id.architectView);
            var config = new StartupConfiguration(App.Self.Wikitude_SDK_Key, StartupConfiguration.Features.Tracking2D);
            /* use  
			   int requiredFeatures = StartupConfiguration.Features.Tracking2D | StartupConfiguration.Features.Geo;
			   if you need both 2d Tracking and Geo
			*/
            var requiredFeatures = StartupConfiguration.Features.Tracking2D/* | StartupConfiguration.Features.Geo*/;
            if ((ArchitectView.getSupportedFeaturesForDevice(Android.App.Application.Context) & requiredFeatures) == requiredFeatures)
            {
                if (architectView != null)
                    architectView.OnCreate(config);
            }
            else
            {
                architectView = null;
                StartActivity(typeof(ErrorActivity));
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (architectView != null)
                architectView.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();

            if (architectView != null)
                architectView.OnPause();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (architectView != null)
            {
                architectView.OnDestroy();
            }
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();

            if (architectView != null)
                architectView.OnLowMemory();
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);

            if (architectView != null)
            {
                architectView.OnPostCreate();

                try
                {
                    architectView.Load(SAMPLE_WORLD_URL);
                }
                catch (Exception ex)
                {
                    Log.Error("WIKITUDE_SAMPLE", ex.ToString());
                }
            }
        }
    }
}
