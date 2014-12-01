using Windows.UI.Xaml.Controls;
using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class ButtonRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "button";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var button = new Button()
            {
                Content = element.TextContent
            };
            parent.Add(button);
        }
    }
}