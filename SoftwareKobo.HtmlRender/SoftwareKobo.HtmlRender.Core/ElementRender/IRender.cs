using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    // ReSharper disable once InconsistentNaming
    public class IRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "i";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            throw new NotImplementedException();
        }
    }
}