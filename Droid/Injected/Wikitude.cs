using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(wikitude_demo.Droid.Wikitude))]
namespace wikitude_demo.Droid
{
    public class Wikitude : IWikitude
    {
        public void LaunchWikitude()
        {
            Forms.Context.StartActivity(typeof(WikitudeActivity));
        }
    }
}

