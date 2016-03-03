using Android.App;
using Android.OS;
using Android.Widget;

namespace wikitude_demo.Droid
{
    [Activity]
    public class ErrorActivity : Activity
    {
        readonly string TITLE = "ERROR";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_error);
            var txt = FindViewById<TextView>(Resource.Id.textView1);
            txt.Text = /*LangResources.WikitudeError*/"Not working";
            Title = TITLE;
        }
    }
}

