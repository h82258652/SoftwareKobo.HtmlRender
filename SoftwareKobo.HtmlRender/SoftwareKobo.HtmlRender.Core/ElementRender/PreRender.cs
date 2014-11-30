using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class PreRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "pre";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            context.RenderNode(element, parent);
        }
    }
}