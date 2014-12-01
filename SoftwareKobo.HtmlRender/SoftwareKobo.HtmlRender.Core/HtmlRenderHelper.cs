using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.HtmlRender.Core
{
    public class HtmlRenderHelper
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.Register(
            "Html", typeof(string), typeof(HtmlRenderHelper),
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
            var html = (string)args.NewValue;
            var renderContext = RenderContextContainer.GetInstance(html);
            if (sender is RichTextBlock)
            {
                renderContext.Render((RichTextBlock)sender);
            }
            else if (sender is Panel)
            {
                renderContext.Render((Panel)sender);
            }
            else if (sender is Border)
            {
                renderContext.Render((Border)sender);
            }
        }
    }
}