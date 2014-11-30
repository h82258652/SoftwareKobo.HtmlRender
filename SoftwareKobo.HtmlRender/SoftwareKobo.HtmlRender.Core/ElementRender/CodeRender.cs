using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class CodeRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "code";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            context.RenderNode(element, parent);
        }
    }
}