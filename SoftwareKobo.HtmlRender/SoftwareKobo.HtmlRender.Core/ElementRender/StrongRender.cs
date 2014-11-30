using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Xaml.Documents;
using SoftwareKobo.HtmlRender.Core.TextContainer;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class StrongRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "strong";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var bold = new Bold();
            parent.Add(bold);
            context.RenderNode(element, new SpanContainer(bold));
        }
    }
}