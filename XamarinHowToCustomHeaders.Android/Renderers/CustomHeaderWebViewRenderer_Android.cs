using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Webkit;
using XamarinHowToCustomHeaders.Controls;
using XamarinHowToCustomHeaders.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomHeaderWebView), typeof(CustomHeaderWebViewRenderer))]
namespace XamarinHowToCustomHeaders.Droid.Renderers
{
    public class CustomHeaderWebViewRenderer : ViewRenderer<CustomHeaderWebView, Android.Webkit.WebView>
    {
        Context _localContext;

        public CustomHeaderWebViewRenderer(Context context) : base(context)
        {
            _localContext = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomHeaderWebView> e)
        {
            base.OnElementChanged(e);

            Android.Webkit.WebView webView = Control as Android.Webkit.WebView;

            if (Control == null)
            {
                webView = new Android.Webkit.WebView(_localContext);
                SetNativeControl(webView);
            }

            if (e.NewElement != null)
            {
                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    ["Authorization"] = Element.CustomHeaderValue // Change this string for a different header key
                };

                webView.Settings.JavaScriptEnabled = true;

                webView.Settings.BuiltInZoomControls = true;
                webView.Settings.SetSupportZoom(true);

                webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
                webView.ScrollbarFadingEnabled = false;

                webView.SetWebViewClient(new CustomWebViewClient(headers));
                UrlWebViewSource source = Element.Source as UrlWebViewSource;
                webView.LoadUrl(source.Url, headers);
            }
        }
    }

    public class CustomWebViewClient : Android.Webkit.WebViewClient
    {
        public Dictionary<string, string> headers { get; set; }

        public CustomWebViewClient(Dictionary<string, string> requestHeaders)
        {
            headers = requestHeaders;
        }
    }
}