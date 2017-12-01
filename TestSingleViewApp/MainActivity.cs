using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net;
using Android.Content;
using Android.Provider;

namespace TestSingleViewApp
{
    [Activity(Label = "TestSingleViewApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 0;
        double data = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.getButton);

            var label = FindViewById<TextView>(Resource.Id.result);
            button.Click += delegate 
            {
                var spChar = Uri.Encode("#");
                var uri = Uri.Parse("tel:*111*502" + spChar);
                var intent = new Intent(Intent.ActionCall, uri);
                StartActivity(intent);

                //count++;
                //label.Text = $"You have {data} data remaining.";
                //button.Text = string.Format("{0} clicks!", count++);

            };
        }
    }
}

