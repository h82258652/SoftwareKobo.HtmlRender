using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.TextContainer
{
    public class ParagraphContainer : ITextContainer
    {
        private readonly Paragraph _paragraph;

        public ParagraphContainer(Paragraph paragraph)
        {
            _paragraph = paragraph;
        }

        public virtual void Add(UIElement control)
        {
            Add(new InlineUIContainer
            {
                Child = control
            });
        }

        public virtual void Add(Block block)
        {
            var richTextBlock = new RichTextBlock();
            richTextBlock.Blocks.Add(block);
            Add(richTextBlock);
        }

        public virtual void Add(Inline inline)
        {
            _paragraph.Inlines.Add(inline);
        }
    }
}