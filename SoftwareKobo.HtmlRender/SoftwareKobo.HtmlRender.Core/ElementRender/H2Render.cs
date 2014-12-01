using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class H2Render : IElementRender
    {
        public string TagName
        {
            get
            {
                return "h2";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var span = new Bold
            {
                FontSize = 1.5 * 16
            };
            parent.Add(span);
            context.RenderNode(element, new SpanContainer(span));
        }
    }
}