using Foundation;
using wikitude_demo.iOS;
using UIKit;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(WikitudeView))]
namespace wikitude_demo.iOS
{
    public class WikitudeView : IWikitude
    {
        WikitudeVC vc;

        public void LaunchWikitude()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            using (var pool = new NSAutoreleasePool())
            {
                pool.InvokeOnMainThread(() =>
                    {
                        try
                        {
                            var board = UIStoryboard.FromName("MainStoryboard_iPhone", null);
                            var ctrl = board.InstantiateViewController("WikitudeVC") as WikitudeVC;
                            var weakThis = new WeakReference<WikitudeVC>(ctrl);
                            weakThis.TryGetTarget(out vc);
                            rootController.PresentViewController(vc, true, null);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception thrown : {0}--{1}", ex.Message, ex.InnerException);
                        }
                    });
            }
        }
    }
}

