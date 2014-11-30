using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using System;
using Windows.System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class ARender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "a";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            // TODO

            var a = (IHtmlAnchorElement)element;

            var anchor = new Hyperlink
            {
                Foreground = new SolidColorBrush(Colors.LightBlue)
            };
            anchor.Click += async (sender, args) =>
            {
                var dialog = new MessageDialog(a.Href, "使用浏览器打开");
                dialog.Commands.Add(new UICommand("确定", async cmd =>
                {
                    var success = await Launcher.LaunchUriAsync(new Uri(a.Href, UriKind.Absolute),
                           new LauncherOptions
                           {
                               TreatAsUntrusted = true,
                               DisplayApplicationPicker = true
                           });
                    if (success)
                    {
                        anchor.Foreground = new SolidColorBrush(Colors.Purple);
                    }
                }));
                dialog.Commands.Add(new UICommand("取消"));
                await dialog.ShowAsync();
            };

            parent.Add(anchor);

            context.RenderNode(element, new SpanContainer(anchor));
        }
    }
}