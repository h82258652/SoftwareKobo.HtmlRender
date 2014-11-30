using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class ObjectRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "object";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
        }
    }
}