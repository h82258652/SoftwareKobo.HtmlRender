using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.TextContainer
{
    public class SpanContainer : ITextContainer
    {
        private readonly Span _span;

        public SpanContainer(Span span)
        {
            _span = span;
        }

        public void Add(UIElement control)
        {
            Add(new InlineUIContainer
            {
                Child = control
            });
        }

        public void Add(Block block)
        {
            var richTextBlock = new RichTextBlock();
            richTextBlock.Blocks.Add(block);
            Add(richTextBlock);
        }

        public void Add(Inline inline)
        {
            _span.Inlines.Add(inline);
        }
    }
}