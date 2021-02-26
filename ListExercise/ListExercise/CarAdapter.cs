using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ListExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListExercise
{
    public class CarAdapter : BaseAdapter<Car>
    {
        List<Car> _items;
        Activity _context;
        
        public CarAdapter(Activity context, List<Car> items)
        {
            _items = items;
            _context = context;
        }

        public override Car this[int position]
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.car_row_layout, null);
            view.FindViewById<TextView>(Resource.Id.manufacturerTextView).Text = _items[position].Manufacturer;
            view.FindViewById<TextView>(Resource.Id.modelTextView).Text = _items[position].Model;
            view.FindViewById<TextView>(Resource.Id.kwTextView).Text = _items[position].Kw.ToString();

            return view;
        }
    }
}