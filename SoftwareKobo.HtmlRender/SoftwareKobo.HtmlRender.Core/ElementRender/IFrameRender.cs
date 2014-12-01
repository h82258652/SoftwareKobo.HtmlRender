using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;
using Windows.UI;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class IframeRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "iframe";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var hyperLink = new Hyperlink
            {
                NavigateUri = new Uri(element.GetAttribute("src"), UriKind.RelativeOrAbsolute),
                Foreground = new SolidColorBrush(Colors.Red)
            };
            hyperLink.Inlines.Add(new Run()
            {
                Text = "无法显示 iframe 的内容，点击使用浏览器查看。"
            });
            parent.Add(hyperLink);
        }
    }
}