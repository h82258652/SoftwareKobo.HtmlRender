using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class H6Render : IElementRender
    {
        public string TagName
        {
            get
            {
                return "h6";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            throw new NotImplementedException();
        }
    }
}