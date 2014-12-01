using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class TableRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "table";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var table = (IHtmlTableElement)element;

            var grid = new Grid();

            foreach (var child in table.Rows)
            {
                var row = child as IHtmlTableRowElement;
                if (row != null)
                {
                    grid.RowDefinitions.Add(new RowDefinition());
                    int columnCount = 0;
                    foreach (var column in row.Cells)
                    {
                        var richTextBlock = new RichTextBlock()
                        {
                            IsTextSelectionEnabled = false
                        };
                        var cellRender = new Border()
                        {
                            Child = richTextBlock,
                            Padding = new Thickness(5)
                        };
                        context.RenderNode(column, new RichTextBlockContainer(richTextBlock));
                        Grid.SetColumn(cellRender, columnCount);
                        Grid.SetRow(cellRender, grid.RowDefinitions.Count - 1);
                        grid.Children.Add(cellRender);

                        columnCount++;

                        if (grid.ColumnDefinitions.Count < columnCount)
                        {
                            grid.ColumnDefinitions.Add(new ColumnDefinition());
                        }
                    }
                }
            }

            parent.Add(grid);
        }
    }
}