using AngleSharp.DOM;

namespace SoftwareKobo.HtmlRender.Core.Interface
{
    public interface IElementRender
    {
        string TagName
        {
            get;
        }

        void RenderElement(IElement element, ITextContainer parent, RenderContextBase context);
    }
}