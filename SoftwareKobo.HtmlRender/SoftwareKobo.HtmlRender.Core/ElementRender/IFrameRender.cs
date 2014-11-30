using System;
using Windows.UI.Xaml.Documents;
using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;

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
            // TODO
            var hyperLink = new Hyperlink();
            hyperLink.NavigateUri = new Uri(element.GetAttribute("src"));
            hyperLink.Inlines.Add(new Run(){Text = "无法显示 iframe 的内容，点击使用浏览器查看。"});
            parent.Add(hyperLink);
        }
    }
}