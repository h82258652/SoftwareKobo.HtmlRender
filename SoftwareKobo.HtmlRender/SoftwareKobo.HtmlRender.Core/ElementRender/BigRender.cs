using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class BigRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "big";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            throw new NotImplementedException();
        }
    }
}