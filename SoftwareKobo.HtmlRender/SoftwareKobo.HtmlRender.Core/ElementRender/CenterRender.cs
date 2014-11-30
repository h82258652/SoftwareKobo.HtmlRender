using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class CenterRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "center";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var paragraph = new Paragraph()
            {
                TextAlignment = TextAlignment.Center
            };
            parent.Add(paragraph);
            context.RenderNode(element, new ParagraphContainer(paragraph));
        }
    }
}