using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
   public class DdRender:IElementRender
    {
        public string TagName
        {
            get { return "dd"; }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            throw new NotImplementedException();
        }
    }
}
