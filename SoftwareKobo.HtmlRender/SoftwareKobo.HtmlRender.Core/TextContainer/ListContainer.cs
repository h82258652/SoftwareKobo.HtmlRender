using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.TextContainer
{
    public abstract class ListContainer : ITextContainer
    {
        private readonly Grid _grid;

        protected ListContainer(Paragraph paragraph)
        {
            _grid = new Grid();
            _grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = GridLength.Auto
            });
            _grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            paragraph.Inlines.Add(new InlineUIContainer
            {
                Child = _grid
            });
        }

        public abstract string ListItemPrefix
        {
            get;
        }

        public virtual void Add(UIElement control)
        {
            int rows = _grid.RowDefinitions.Count;
            _grid.RowDefinitions.Add(new RowDefinition());

            var textBlock = new TextBlock
            {
                Text = ListItemPrefix,
                Margin = new Thickness(0, 5, 0, 5),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Grid.SetColumn(textBlock, 0);
            Grid.SetRow(textBlock, rows);
            _grid.Children.Add(textBlock);

            if ((control is FrameworkElement) == false)
            {
                // UIElement can set column and row,
                // so use a border.
                var border = new Border
                {
                    Child = control
                };
                control = border;
            }
            Grid.SetColumn((FrameworkElement)control, 1);
            Grid.SetRow((FrameworkElement)control, rows);
            _grid.Children.Add(control);
        }

        public virtual void Add(Block block)
        {
            var richTextBlock = new RichTextBlock
            {
                Margin = new Thickness(5)
            };
            richTextBlock.Blocks.Add(block);
            Add(richTextBlock);
        }

        public virtual void Add(Inline inline)
        {
            var paragraph = new Paragraph();
            paragraph.Inlines.Add(inline);
            Add(paragraph);
        }
    }
}