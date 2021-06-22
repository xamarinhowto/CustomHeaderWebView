using System;
using Foundation;
using XamarinHowToCustomHeaders.iOS.Renderers;
using XamarinHowToCustomHeaders.Controls;
using UIKit;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomHeaderWebView), typeof(CustomHeaderWebViewRenderer))]
namespace XamarinHowToCustomHeaders.iOS.Renderers
{
    public class CustomHeaderWebViewRenderer : ViewRenderer<CustomHeaderWebView, WKWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomHeaderWebView> e)
        {
            base.OnElementChanged(e);

            var webView = Control as WKWebView;

            if (webView == null)
            {
                webView = new WKWebView(new CoreGraphics.CGRect(), new WKWebViewConfiguration());
                webView.SizeToFit();
                SetNativeControl(webView);
            }

            if (e.NewElement != null)
            {
                var headerKey = new NSString("Authorization"); // Change this string for a different header key
                var headerValue = new NSString(Element.CustomHeaderValue);
                var dictionary = new NSDictionary(headerKey, headerValue);

                UrlWebViewSource source = (Xamarin.Forms.UrlWebViewSource)Element.Source;
                var webRequest = new NSMutableUrlRequest(new NSUrl(source.Url));
                webRequest.Headers = dictionary;

                Control.LoadRequest(webRequest);
            }
        }
    }
}