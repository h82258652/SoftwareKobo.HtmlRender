using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Xaml.Documents;
using SoftwareKobo.HtmlRender.Core.TextContainer;

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
            parent.Add(span);
            context.RenderNode(element, new SpanContainer(span));
        }
    }
}