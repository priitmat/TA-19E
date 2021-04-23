using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using StarwarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarwarsApp
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.people_detail_layout);

            var nameText = FindViewById<TextView>(Resource.Id.nameTextview);
            
            var details = JsonConvert.DeserializeObject<PeopleDetails>(Intent.GetStringExtra("PeopleDetail"));

            nameText.Text = details.name;

            // Create your application here
        }
    }
}