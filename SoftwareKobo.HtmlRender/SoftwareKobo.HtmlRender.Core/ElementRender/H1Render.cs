using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class H1Render : IElementRender
    {
        public string TagName
        {
            get
            {
                return "h1";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            // TODO
            var span = new Bold();
            span.FontSize = 2 * 16;
            parent.Add(span);
            context.RenderNode(element, new SpanContainer(span));
        }
    }
}