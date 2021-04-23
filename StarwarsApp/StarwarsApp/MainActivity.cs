using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using StarwarsApp.Models;
using StarwarsApp.Services;
using StarwarsApp.Adapters;
using System;
using Android.Content;

namespace StarwarsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        People data = new People();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            var remoteDataService = new RemoteDataService();
            data = await remoteDataService.GetStarwarsPeople();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var listview = FindViewById<ListView>(Resource.Id.peopleListView);
            listview.Adapter = new PeopleAdapter(this, data.results);
            listview.ItemClick += OnListItemClick;
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowNumberThatWasClicked = e.Position;
            
            var t = data.results[rowNumberThatWasClicked];            

            var intent = new Intent(this, typeof(DetailActivity));            
            intent.PutExtra("PeopleDetail", JsonConvert.SerializeObject(t));
            StartActivity(intent);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}