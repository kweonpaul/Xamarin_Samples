using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using static Android.Widget.Adapter;
using static Android.App.Fragment;
using Android.Content.PM;
using System.IO;
using Android.Content.Res;
using System.Collections.Generic;

namespace TextMemo
{
    [Activity(Label = "TextMemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;

       

    protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.MyListView);

            mItems = new List<string>();
            mItems.Add("Bob");
            mItems.Add("Paul");
            mItems.Add("John");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);

            mListView.Adapter = adapter;


            // Create a new TextView and set it as our view
            TextView tv = new TextView(this);

            // Read the contents of our asset
            string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("Test.txt")))
            {
                content = sr.ReadToEnd();
            }

            // Set TextView.Text to our asset content
            tv.Text = content;
            SetContentView(tv);
        }
    }
}
