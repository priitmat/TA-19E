using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ListExercise.Models;

namespace ListExercise
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;


            var items = new List<Car>
            {
                new Car{ Manufacturer = "Ford", Model = "Focus", Kw = 80},
                new Car{ Manufacturer = "Bmw", Model = "3 seeria", Kw = 35},
                new Car{ Manufacturer = "Mercedes", Model = "E klass", Kw = 263},
                new Car{ Manufacturer = "Volkswagen", Model = "Passat", Kw = 343},
                new Car{ Manufacturer = "Fiat", Model = "Punto", Kw = 555},
                new Car{ Manufacturer = "Ferrari", Model = "360", Kw = 34},
                new Car{ Manufacturer = "Lamborghini", Model = "Hurracan", Kw = 234},
                new Car{ Manufacturer = "Ford", Model = "Focus", Kw = 80},
                new Car{ Manufacturer = "Bmw", Model = "3 seeria", Kw = 35},
                new Car{ Manufacturer = "Mercedes", Model = "E klass", Kw = 263},
                new Car{ Manufacturer = "Volkswagen", Model = "Passat", Kw = 343},
                new Car{ Manufacturer = "Fiat", Model = "Punto", Kw = 555},
                new Car{ Manufacturer = "Ferrari", Model = "360", Kw = 34},
                new Car{ Manufacturer = "Lamborghini", Model = "Hurracan", Kw = 234},
                new Car{ Manufacturer = "Ford", Model = "Focus", Kw = 80},
                new Car{ Manufacturer = "Bmw", Model = "3 seeria", Kw = 35},
                new Car{ Manufacturer = "Mercedes", Model = "E klass", Kw = 263},
                new Car{ Manufacturer = "Volkswagen", Model = "Passat", Kw = 343},
                new Car{ Manufacturer = "Fiat", Model = "Punto", Kw = 555},
                new Car{ Manufacturer = "Ferrari", Model = "360", Kw = 34},
                new Car{ Manufacturer = "Lamborghini", Model = "Hurracan", Kw = 234},
                new Car{ Manufacturer = "Ford", Model = "Focus", Kw = 80},
                new Car{ Manufacturer = "Bmw", Model = "3 seeria", Kw = 35},
                new Car{ Manufacturer = "Mercedes", Model = "E klass", Kw = 263},
                new Car{ Manufacturer = "Volkswagen", Model = "Passat", Kw = 343},
                new Car{ Manufacturer = "Fiat", Model = "Punto", Kw = 555},
                new Car{ Manufacturer = "Ferrari", Model = "360", Kw = 34},
                new Car{ Manufacturer = "Lamborghini", Model = "Hurracan", Kw = 234},
                new Car{ Manufacturer = "Ford", Model = "Focus", Kw = 80},
                new Car{ Manufacturer = "Bmw", Model = "3 seeria", Kw = 35},
                new Car{ Manufacturer = "Mercedes", Model = "E klass", Kw = 263},
                new Car{ Manufacturer = "Volkswagen", Model = "Passat", Kw = 343},
                new Car{ Manufacturer = "Fiat", Model = "Punto", Kw = 555},
                new Car{ Manufacturer = "Ferrari", Model = "360", Kw = 34},
                new Car{ Manufacturer = "Lamborghini", Model = "Hurracan", Kw = 234},
            };

            var carListView = FindViewById<ListView>(Resource.Id.carListView);
            carListView.Adapter = new CarAdapter(this, items);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
