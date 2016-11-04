using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Android.Graphics;

namespace WebView_Tutorial
{
    [Activity(Label = "WebView_Tutorial", MainLauncher = true, Icon = "@drawable/icon", Theme ="@android:style/Theme.Black.NoTiltBar")]
    public class MainActivity : Activity
    {
        private WebView mWebView;
        private EditText mTxtURL;
        private ProgressBar mProgressBar;
        private WebClient mWebClient;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            mWebClient = new WebClient();

            mWebClient.mOnProgressChanged += (int state) =>
            {
                if (state == 0)
                {
                    // Done Loading, hide progress bar
                    mProgressBar.Visibility = ViewStates.Invisible;
                }

                else
                {
                    mProgressBar.Visibility = ViewStates.Visible;
                }
            };


            mWebView = FindViewById<WebView>(Resource.Id.webView);
            mTxtURL = FindViewById<EditText>(Resource.Id.txtURL);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar)

            mWebView.Settings.JavaScriptEnabled = true;
            mWebView.LoadUrl("http://www.google.com");
            mWebView.SetWebViewClient(new WebViewClient());

            mTxtURL.Click += mTxtURL_Click;
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (e.KeyCode == Keycode.Back)
            {
                mWebView.GoBack();
            }

            return true;
        }

        void mTxtURL_Click(object sender, EventArgs e)
        {
            mWebClient.ShouldOverrideUnderUrlLoading(mWebView, mTxtURL.Text);
        }
    }

    public class WebClient : WebViewClient
    {
        public delegate void ToggleProgressBar(int state);
        public ToggleProgressBar mOnProgressChanged;

        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }

        public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
        {   
            if(mOnProgressChanged != null)
            {
                mOnProgressChanged.Invoke(1);
            }
            base.OnPageStarted(view, url, favicon);
        }

        public override void OnPageFinished(WebView view, string url)
        {
            if (mOnProgressChanged != null)
            {
                mOnProgressChanged.Invoke(0);
            }
            base.OnPageFinished(view, url);
        }
    }
}

