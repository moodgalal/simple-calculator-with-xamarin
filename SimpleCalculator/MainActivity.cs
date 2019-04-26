using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Controls;

namespace SimpleCalculator
{
    [Activity(Label = "SimpleCalculator", MainLauncher = true, Icon = "@drawable/joker")]
    public class MainActivity : Activity
    {

        protected override void OnCreate ( Bundle bundle )
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            var num1 = FindViewById<EditText>(Resource.Id.num1);
            var num2 = FindViewById<EditText>(Resource.Id.num2);
            var button = FindViewById<Button>(Resource.Id.button1);

            AlertCenter.Default.Init(Application);
            button.Click += delegate
              {
                try
                  {
                      Intent resultHandler = new Intent(this, typeof(resultActivity));
                      string result = (Convert.ToInt32(num1.Text) + Convert.ToInt64(num2.Text)).ToString();
                      resultHandler.PutExtra("Result", result);
                      StartActivity(resultHandler);
                  }
                  catch
                  {
                      AlertCenter.Default.PostMessage("Unvalid operation", "Please check that you have entered a values", Resource.Drawable.Error);
                  } 
                //else if(num1==null)
                //  {
                //      AlertCenter.Default.PostMessage("Unvalid operation", "Please enter a value for the First Number", Resource.Drawable.Error);
                //  }
                //  else if(num2 == null)
                //  {
                //      AlertCenter.Default.PostMessage("Unvalid operation", "Please enter a value for the Second Number", Resource.Drawable.Error);
                //  }
                //else
                //      AlertCenter.Default.PostMessage("Unvalid operation", "Please enter a value for the First Number and the second number", Resource.Drawable.Error);
             };
        }
    }
}
