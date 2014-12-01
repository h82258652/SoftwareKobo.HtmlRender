using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class TextareaRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "textarea";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var richEditBox = new RichEditBox();
            richEditBox.Document.SetText(TextSetOptions.None, element.TextContent);
            parent.Add(richEditBox);
        }
    }
}