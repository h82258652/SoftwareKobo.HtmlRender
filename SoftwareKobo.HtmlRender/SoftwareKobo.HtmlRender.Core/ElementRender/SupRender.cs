using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class SupRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "sup";
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