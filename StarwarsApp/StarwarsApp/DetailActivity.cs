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
        PeopleDetails _details;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.people_detail_layout);

            var nameText = FindViewById<TextView>(Resource.Id.nameTextview);
            var showMoreInfoButton = FindViewById<Button>(Resource.Id.showMoreInfoButton);
            var peopleDetailInJson = Intent.GetStringExtra("PeopleDetail");
            _details = JsonConvert.DeserializeObject<PeopleDetails>(peopleDetailInJson);

            nameText.Text = _details.name;
            showMoreInfoButton.Click += ShowMoreInfoButton_Click; 
            // Create your application here
        }

        private void ShowMoreInfoButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(WebviewActivity));
            intent.PutExtra("url", GenerateUrl());
            StartActivity(intent);            
        }

        private string GenerateUrl()
        {
            var baseUrl = "https://www.google.com/search?q=";
            var phraseToSearch = _details.name;
            var url = baseUrl + phraseToSearch;
            return url;
        }
    }
}