using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class BRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "b";
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