using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml.Documents;

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
            var italic = new Italic();
            parent.Add(italic);
            context.RenderNode(element, new SpanContainer(italic));
        }
    }
}