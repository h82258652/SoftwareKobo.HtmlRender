using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class BrRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "br";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            if (element.PreviousElementSibling is IHtmlFieldSetElement)
            {
                return;
            }
            if (element.NextElementSibling is IHtmlFieldSetElement)
            {
                return;
            }
            parent.Add(new LineBreak());
        }
    }
}