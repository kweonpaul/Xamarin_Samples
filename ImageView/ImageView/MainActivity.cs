using Android.App;
using Android.Widget;
using Android.OS;

namespace ImageView
{
    [Activity(Label = "ImageView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var gridview = FindViewById<GridView>(Resource.Id.gridview);
            gridview.Adapter = new ImageAdapter(this);
            gridview.ItemClick += delegate (object sender, ItemEventArgs args) {
                Toast.MakeText(this, args.Position.ToString(), ToastLength.Short).Show();
            };
        }
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        ImageView imageView;

        if (convertView == null)
        {
            // if it's not recycled, initialize some attributes
            imageView = new ImageView(context);
            imageView.LayoutParameters = new AbsListView.LayoutParams(85, 85);
            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
            imageView.SetPadding(8, 8, 8, 8);
        }
        else
        {
            imageView = (ImageView)convertView;
        }
        imageView.SetImageResource(thumbIds[position]);
        return imageView;
    }
}

