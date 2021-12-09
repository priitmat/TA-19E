﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NotesApp.Core;
using NotesApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesApp.Droid.Adapters
{
    public class NotesAdapter : BaseAdapter<Note>
    {
        List<Note> _items;
        Activity _context;

        public NotesAdapter(Activity context, List<Note> items)
        {
            _items = items;
            _context = context;
        }

        public override Note this[int position]
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
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = _items[position].Heading;

            return view;
        }
    }
}