using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Extension;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class SpanRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "span";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var span = new Span();

            var color = element.Style("color");
            if (string.IsNullOrEmpty(color) == false)
            {
                color = color.Trim().TrimStart('#');
                if (color.Length == 6)
                {
                    var sR = color.Substring(0, 2);
                    var sG = color.Substring(2, 2);
                    var sB = color.Substring(4, 2);
                    byte r, g, b;
                    if (byte.TryParse(sR, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out r)
                        && byte.TryParse(sG, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out g)
                        && byte.TryParse(sB, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out b))
                    {
                        var value = Color.FromArgb(255, r, g, b);
                        if (value != Colors.White && value != Colors.Black)
                        {
                            span.Foreground = new SolidColorBrush(value);
                        }
                    }
                }
            }

            parent.Add(span);
            context.RenderNode(element, new SpanContainer(span));
        }
    }
}