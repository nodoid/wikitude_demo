
using Xamarin.Forms;

namespace wikitude_demo
{
    public class App : Application
    {
        public static App Self { get; private set; }

        public string Wikitude_SDK_Key { get; private set; } = "TE2aBzgPu/Gw3LkVsGtiVM6PHjD9hMWnJKzoqsZUwMZFj02Qck7lpgFR+fEy4CVQhUSUbOLJH3S9UITCq3SW8B6KrrAeJLzghONILBXStJMNXwSNy4jz9HyQZTtlcL3vYUB8qLW9A2xs6VGO3T1Kxhp88kG/NCIi2uyGbdX7Fm1TYWx0ZWRfX2LmEsNhIN48hzc/w+7m3K2STcpca74vxhkTBJ4AnyoMuIEQ0P9xcxDUzcKRktg1mbU+n+a92+jo8MtJ4td2r392NiUgjaiQkWjLDKkadQqc++5JhQurSIHZqF2dpTZblHFKtw5E2FNn2BWrYo44U/WSYxkfqdJX2OilCePHcaFO+G7/1wP8JGu4myrk/z3cLlYhLUR1smfDByEfHKYE7h+scmlpSpBMus7dFTSOwaedln9sViYzuCAgojK8ScJPGObtBje4AwajdCjw1AgxseSFH6m1Ox3PNLNk1z8sJLWOZtIjpsLTLtRAWy0k0725qO2IJgnJ367kqmCTXlxLbKz3A4y2vws3DzWBkIb7HRRrZKsu5HXAXIWz3fZik01mMSKYnshp33lAIW/5Gz1pPd1yb+mjQgZAdUQAaHqxgVi65GKRnroFwjJEwabM+/dyYl0DRt2WL/pnTluc9/G+GIkGsbwH/0ASG9gMhlxMkPxQylAYhoXLWwx2p3nzMBKQbia6mgyefnpoOHdSw69xYVmPEC9mnspehpwqkE0tgUcc+OIiF6bcRmRJxeI1KW1yCSzOy4ReS3G1GZxyGtmRyS601nOJQPqm6g==";
        public App()
        {
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Button {
                            Text = "Click here to launch Wikitude AR",
                            Command = new Command(()=>DependencyService.Get<IWikitude>().LaunchWikitude())
                        }
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

