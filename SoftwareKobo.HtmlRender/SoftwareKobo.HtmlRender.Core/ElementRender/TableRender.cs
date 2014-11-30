using Windows.UI.Xaml.Controls;
using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;

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
            // TODO
            var webview = new WebView();
            webview.Height = 300;
            webview.Width = 300;
            webview.NavigateToString(element.ToHtml());
            parent.Add(webview);
        }
    }
}