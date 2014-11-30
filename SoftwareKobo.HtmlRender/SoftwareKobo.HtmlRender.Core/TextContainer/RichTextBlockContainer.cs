﻿using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.TextContainer
{
    public class RichTextBlockContainer : ITextContainer
    {
        private readonly RichTextBlock _richTextBlock;

        public RichTextBlockContainer(RichTextBlock richTextBlock)
        {
            _richTextBlock = richTextBlock;
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
            _richTextBlock.Blocks.Add(block);
        }

        public virtual void Add(Inline inline)
        {
            var paragraph = new Paragraph();
            paragraph.Inlines.Add(inline);
            Add(paragraph);
        }
    }
}