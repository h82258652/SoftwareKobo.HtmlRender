using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.TextContainer
{
    public class UnorderListContainer : ListContainer
    {
        public UnorderListContainer(Paragraph paragraph)
            : base(paragraph)
        {
        }

        public override string ListItemPrefix
        {
            get
            {
                return "●";
            }
        }
    }
}