using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCosmeticsAE
{
    [Activity(Label = "Services")]
    public class Services : Activity
    {
        
        Button btnIndex;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Services);

            btnIndex = FindViewById<Button>(Resource.Id.btnIndex);

            btnIndex.Click += BtnIndex_Click;
            // Create your application here
        }

        private void BtnIndex_Click(object sender, EventArgs e)
        {
            Intent HomePage = new Intent(this, typeof(Home));
            StartActivity(HomePage);
        }
    }
}