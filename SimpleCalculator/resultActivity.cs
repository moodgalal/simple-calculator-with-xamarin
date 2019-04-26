using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SimpleCalculator
{
    [Activity(Label = "resultActivity")]
    public class resultActivity : Activity
    {
        protected override void OnCreate ( Bundle savedInstanceState )
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.showingResult);
            var resultArea = FindViewById<TextView>(Resource.Id.resultArea);
            var returnButton = FindViewById<Button>(Resource.Id.returnButton);

            string resultValue = Intent.GetStringExtra("Result");
            resultArea.Text = resultValue;
            returnButton.Click += delegate
              {
                  var intent = new Intent(this, typeof(MainActivity))
                                     .SetFlags(ActivityFlags.ReorderToFront);
                  StartActivity(intent);
              };
        }
    }
}