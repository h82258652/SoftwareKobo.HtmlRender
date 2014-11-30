using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
   public class CanvasRender:IElementRender
    {
        public string TagName
        {
            get { return "canvas"; }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            throw new NotImplementedException();
        }
    }
}
