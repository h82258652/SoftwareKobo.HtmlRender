using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class UlRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "ul";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var paragraph = new Paragraph();
            parent.Add(paragraph);
            context.RenderNode(element, new UnorderListContainer(paragraph));
        }
    }
}