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

namespace Calculator
{
    [Activity(Label = "TipcalcActivity")]
    public class TipcalcActivity : Activity
    {
        EditText _subtotalEditText;
        TextView _tipTextView;
        SeekBar _tipSeekbar;
        TextView _billTotalTextView;
        TextView _tipTotalTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tipcalc_layout);
            // Create your application here

            _subtotalEditText = FindViewById<EditText>(Resource.Id.subTotalEditText);
            _tipTextView = FindViewById<TextView>(Resource.Id.tipTextView);
            _tipSeekbar = FindViewById<SeekBar>(Resource.Id.tipSeekBar);
            _billTotalTextView = FindViewById<TextView>(Resource.Id.billTotalTextView);
            _tipTotalTextView = FindViewById<TextView>(Resource.Id.tipTotalTextView);

            _tipSeekbar.ProgressChanged += TipSeekbar_ProgressChanged;          
        }


        private void TipSeekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            _tipTextView.Text = e.Progress.ToString();
        }
    }
}