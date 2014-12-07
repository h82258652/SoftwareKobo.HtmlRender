using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class LegendRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "legend";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var groupbox = parent as GroupBoxContainer;
            if (groupbox != null)
            {
                groupbox.SetHeader(element.TextContent);
            }
        }
    }
}