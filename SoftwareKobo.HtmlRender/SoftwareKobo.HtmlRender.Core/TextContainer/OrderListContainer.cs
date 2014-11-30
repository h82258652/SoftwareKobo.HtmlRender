using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.TextContainer
{
    public class OrderListContainer : ListContainer
    {
        public OrderListContainer(Paragraph paragraph)
            : this(paragraph, 1)
        {
        }

        public OrderListContainer(Paragraph paragraph, int startIndex)
            : base(paragraph)
        {
            Index = startIndex;
        }

        public int Index
        {
            get;
            set;
        }

        public override string ListItemPrefix
        {
            get
            {
                return string.Format("{0}.", Index);
            }
        }

        public override void Add(UIElement control)
        {
            base.Add(control);
            Index++;
        }
    }
}