using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinHowToCustomHeaders.Controls
{
    public class CustomHeaderWebView : WebView
    {
        public static readonly BindableProperty CustomHeaderValueProperty = BindableProperty.Create(
            propertyName: nameof(CustomHeaderValue),
            returnType: typeof(string),
            declaringType: typeof(CustomHeaderWebView),
            defaultValue: default(string)
        );

        public string CustomHeaderValue
        {
            get => (string)GetValue(CustomHeaderValueProperty);
            set => SetValue(CustomHeaderValueProperty, value);
        }
    }
}