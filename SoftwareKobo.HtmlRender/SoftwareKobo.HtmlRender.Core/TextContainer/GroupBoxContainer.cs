using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.HtmlRender.Core.TextContainer
{
    public class GroupBoxContainer : ITextContainer
    {
        private readonly RichTextBlockContainer _innerContainer;

        private readonly TextBlock _titleBlock;

        public GroupBoxContainer(Span span)
        {
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition
            {
                Height = GridLength.Auto
            });
            grid.RowDefinitions.Add(new RowDefinition());

            _titleBlock = new TextBlock();
            grid.Children.Add(_titleBlock);

            var border = new Border
            {
                BorderBrush = new SolidColorBrush(Colors.Gray),
                BorderThickness = new Thickness(1, 0, 0, 1),
                Margin = new Thickness(5, 0, 0, 5),
                Padding = new Thickness(3, 0, 0, 3)
            };
            Grid.SetRow(border, 1);
            grid.Children.Add(border);

            var richTextBlock = new RichTextBlock()
            {
                IsTextSelectionEnabled = false
            };
            border.Child = richTextBlock;
            _innerContainer = new RichTextBlockContainer(richTextBlock);

            span.Inlines.Add(new InlineUIContainer()
            {
                Child = grid
            });
        }

        public void Add(UIElement control)
        {
            _innerContainer.Add(control);
        }

        public void Add(Block block)
        {
            _innerContainer.Add(block);
        }

        public void Add(Inline inline)
        {
            _innerContainer.Add(inline);
        }

        public void SetHeader(string header)
        {
            _titleBlock.Text = header;
        }
    }
}