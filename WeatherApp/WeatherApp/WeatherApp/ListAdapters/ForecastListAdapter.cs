using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using WeatherApp.Models;

namespace WeatherApp.ListAdapters
{
    public class ForecastListAdapter : BaseAdapter<WeatherItem>
    {
        List<WeatherItem> _items;
        Activity _context;

        public ForecastListAdapter(Activity context, List<WeatherItem> items)
        {
            _items = items;
            _context = context;
        }

        public override WeatherItem this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.forecast_row_layout, null);
            view.FindViewById<TextView>(Resource.Id.forcastTimeTextView).Text = _items[position].dt_txt;
            //view.FindViewById<TextView>(Resource.Id.ageTextView).Text = _items[position].birth_year;

            return view;
        }
    }
}
