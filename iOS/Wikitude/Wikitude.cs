using System;
using Foundation;
using UIKit;
using Wikitude.Architect;

namespace wikitude_demo.iOS
{
    public partial class WikitudeVC : UIViewController
    {
        WTArchitectView architectView;

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public WikitudeVC(IntPtr handle)
            : base(handle)
        {
            //Console.WriteLine(handle);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (architectView != null)
            {
                architectView.Dispose();
                architectView = null;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            GC.Collect();
        }

        public void StartAR()
        {
            if (architectView != null)
            {
                if (!architectView.IsRunning)
                {
                    architectView.Start(null, null);
                    Console.WriteLine("Wikitude SDK version {0} is running", WTArchitectView.SDKVersion);
                }
            }
        }

        public void StopAR()
        {
            if (architectView != null)
                if (architectView.IsRunning)
                {
                    architectView.Stop();
                }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (architectView != null)
            {
                architectView.Dispose();
                architectView = null;
            }

            architectView = new WTArchitectView();
            View.AddSubview(architectView);

            architectView.TranslatesAutoresizingMaskIntoConstraints = false;

            var views = new NSDictionary(new NSString("architectView"), architectView);
            View.AddConstraints(NSLayoutConstraint.FromVisualFormat("|-[architectView]-|", NSLayoutFormatOptions.AlignAllBaseline, null, views));
            View.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-[architectView]-|", NSLayoutFormatOptions.AlignAllCenterY, null, views));

            architectView.SetLicenseKey(App.Self.Wikitude_SDK_Key);

            try
            {
                var path = NSBundle.MainBundle.BundleUrl.AbsoluteString + "1_ImageRecognition_1_ImageOnTarget/index.html";
                architectView.LoadArchitectWorldFromURL(NSUrl.FromString(path), Wikitude.Architect.WTFeatures.WTFeature_2DTracking);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thown {0}--{1}", ex.Message, ex.InnerException);
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            StartAR();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            if (architectView != null)
            {
                architectView.Stop();
                architectView.RemoveFromSuperview();
            }
            Dispose(true);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            StopAR();
        }

        public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
        {
            base.WillRotate(toInterfaceOrientation, duration);
            if (architectView != null)
                architectView.SetShouldRotateToInterfaceOrientation(true, toInterfaceOrientation);
        }

        public override bool ShouldAutorotate()
        {
            return true;
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.All;
        }
    }
}

