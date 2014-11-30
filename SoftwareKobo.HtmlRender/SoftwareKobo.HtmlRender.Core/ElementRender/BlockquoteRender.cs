using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class BlockquoteRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "blockquote";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = new SolidColorBrush(Colors.Gray),
                Margin = new Thickness(0, 5, 0, 5),
                Padding = new Thickness(10)
            };
            parent.Add(border);

            var richTextBlock = new RichTextBlock();
            border.Child = richTextBlock;
            context.RenderNode(element, new RichTextBlockContainer(richTextBlock));
        }
    }
}