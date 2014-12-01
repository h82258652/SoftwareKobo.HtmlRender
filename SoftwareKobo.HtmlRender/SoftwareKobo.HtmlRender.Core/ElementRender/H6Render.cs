using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class H6Render : IElementRender
    {
        public string TagName
        {
            get
            {
                return "h6";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var span = new Span
            {
                FontSize = 0.67 * 16
            };
            parent.Add(span);
            context.RenderNode(element, new SpanContainer(span));
        }
    }
}