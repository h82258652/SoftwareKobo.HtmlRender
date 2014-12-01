using System.Diagnostics;
using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Interface;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class InputRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "input";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var input = (IHtmlInputElement)element;
            var type = input.Type ?? string.Empty;
            type = type.Trim();
            if (type.Length == 0)
            {
                type = "text";
            }
            type = type.ToLower();

            switch (type)
            {
                case "text":
                    {
                        var textbox = new TextBox
                        {
                            Text = input.Value
                        };
                        parent.Add(textbox);
                        break;
                    }
                case "button":
                    {
                        var button = new Button
                        {
                            Content = input.Value
                        };
                        parent.Add(button);
                        break;
                    }
                default:
                    {
                        if (Debugger.IsAttached)
                        {
                            Debugger.Break();
                        }
                        var textblock = new TextBlock
                        {
                            Text = string.Format("input type=\"{0}\" is not support.", input.Type)
                        };
                        parent.Add(textblock);
                        break;
                    }
            }
        }
    }
}