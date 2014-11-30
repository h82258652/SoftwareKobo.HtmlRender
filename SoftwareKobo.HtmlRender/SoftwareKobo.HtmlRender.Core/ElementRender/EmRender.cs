using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class EmRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "em";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var italic = new Italic();
            parent.Add(italic);
            context.RenderNode(element, new SpanContainer(italic));
        }
    }
}