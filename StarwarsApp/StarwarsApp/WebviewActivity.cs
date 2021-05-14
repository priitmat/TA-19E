using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarwarsApp
{
    [Activity(Label = "WebviewActivity")]
    public class WebviewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.webview_layout);

            var webview = FindViewById<WebView>(Resource.Id.webView1);

            var  url = Intent.GetStringExtra("url");
            webview.SetWebViewClient(new StarWarsWebviewClient());
            webview.Settings.JavaScriptEnabled = true;                
            webview.LoadUrl(url);            
        }
    }
}