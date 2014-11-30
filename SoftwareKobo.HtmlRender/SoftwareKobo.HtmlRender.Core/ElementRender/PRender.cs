using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;
using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class PRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "p";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var paragraph = new Paragraph
            {
                Margin = new Thickness(0, 10, 0, 10)
            };

            parent.Add(paragraph);
            context.RenderNode(element, new ParagraphContainer(paragraph));
        }
    }
}