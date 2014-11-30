using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class HrRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "hr";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var line = new Rectangle
            {
                MinWidth = double.MaxValue,
                MinHeight = 1,
                Fill = new SolidColorBrush(Colors.Gray),
                Margin = new Thickness(0, 5, 0, 5)
            };
            parent.Add(line);
        }
    }
}