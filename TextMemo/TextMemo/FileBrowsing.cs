using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TextMemo
{
    public class FileListRowViewHolder : Java.Lang.Object
    {
        public FileListRowViewHolder(TextView textView, ImageView imageView)
        {
            TextView = textView;
            ImageView = imageView;
        }
        public ImageView ImageView { get; private set; }
        public TextView TextView { get; private set; }
        public void Update(string fileName, int fileImageResourceId)
        {
            TextView.Text = fileName;
            ImageView.SetImageResource(fileImageResourceId);
        }
    }
}