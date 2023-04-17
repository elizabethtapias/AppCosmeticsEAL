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
    [Activity(Label = "Home")]
    public class Home : Activity
    {
        Toolbar toolbarmenu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);


            SetActionBar(toolbarmenu);
            ActionBar.Title = "Main";

            // Create your application here
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.services:
                    Intent servicios = new Intent(this, typeof(Services));
                    StartActivity(servicios);

                    break;
                case Resource.Id.portfolio:
                    Intent portafolio = new Intent(this, typeof(Portfolio));
                    StartActivity(portafolio);

                    break;

                case Resource.Id.promocions:
                    Intent promociones = new Intent(this, typeof(Portfolio));
                    StartActivity(promociones);

                    break;

                case Resource.Id.contact:
                    Intent contacto = new Intent(this, typeof(Contact));
                    StartActivity(contacto);

                    break;

                case Resource.Id.AdmManagement:
                    Intent AdmManagement = new Intent(this, typeof(AdmManagement));
                    StartActivity(AdmManagement);

                    break;
                default:
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}