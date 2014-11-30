using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class H3Render : IElementRender
    {
        public string TagName
        {
            get
            {
                return "h3";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            // TODO
            var span = new Span();
            span.FontSize = 1.17 * 16;
            parent.Add(span);
            context.RenderNode(element, new SpanContainer(span));
        }
    }
}