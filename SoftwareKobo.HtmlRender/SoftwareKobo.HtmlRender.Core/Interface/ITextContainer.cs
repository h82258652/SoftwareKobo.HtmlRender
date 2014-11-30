using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core.Interface
{
    public interface ITextContainer
    {
        void Add(UIElement control);

        void Add(Block block);

        void Add(Inline inline);
    }
}