using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.HtmlRender.Core
{
    public class HtmlRenderHelper
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.Register(
            "PropertyType", typeof(string), typeof(HtmlRenderHelper),
            new PropertyMetadata(default(string), OnHtmlChanged));

        public static string GetHtml(DependencyObject obj)
        {
            return (string)obj.GetValue(HtmlProperty);
        }

        public static void SetHtml(DependencyObject obj, string value)
        {
            obj.SetValue(HtmlProperty, value);
        }

        private static void OnHtmlChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            // TODO
            var renderContext = new RenderContextBase((string)args.NewValue);

            var richTextBlock = sender as RichTextBlock;
            renderContext.Render(richTextBlock);
        }
    }
}