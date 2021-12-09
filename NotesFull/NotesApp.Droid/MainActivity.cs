using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using NotesApp.Core;
using NotesApp.Core.Models;
using NotesApp.Droid.Adapters;
using System.Collections.Generic;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace NotesApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private List<Note> _notes = new List<Note>();
        static public SqlService SqlService = new SqlService();

        private ListView _listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            AppCenter.Start("4d4370d3-f472-47d4-9ae6-9420935894c8",
                   typeof(Analytics), typeof(Crashes));

            SetContentView(Resource.Layout.activity_main);

            SqlService.CreateTable();
            _notes = SqlService.GetAllNotes();

            var addButton = FindViewById<Button>(Resource.Id.addButton);
            _listView = FindViewById<ListView>(Resource.Id.listView1);


            _listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                var intent = new Intent(this, typeof(NoteDetailActivity));
                intent.PutExtra("mode", "edit");
                intent.PutExtra("id", _notes[args.Position].Id);

                StartActivity(intent);
            };

            addButton.Click += addButton_Click;

        }

        protected override void OnResume()
        {
            base.OnResume();

            _notes = SqlService.GetAllNotes();
            var ListAdapter = new NotesAdapter(this, _notes);
            _listView.Adapter = ListAdapter;
        }


        private void addButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(NoteDetailActivity));
            intent.PutExtra("mode", "add");
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
