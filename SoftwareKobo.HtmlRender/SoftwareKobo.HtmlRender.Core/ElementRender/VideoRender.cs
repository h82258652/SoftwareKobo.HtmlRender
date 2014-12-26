using System.Linq;
using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class VideoRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "video";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var video = (IHtmlVideoElement)element;

            string source = video.Source;

            if (string.IsNullOrEmpty(source))
            {
                var sourceElement =
                    video.Children.FirstOrDefault(
                        temp => string.Equals(temp.TagName, "source", StringComparison.OrdinalIgnoreCase) && string.Equals(temp.GetAttribute("type"), "video/mp4", StringComparison.OrdinalIgnoreCase));
                if (sourceElement != null)
                {
                    source = sourceElement.GetAttribute("src");
                }
            }

            var mediaElement = new MediaElement
            {
                AreTransportControlsEnabled = true,
                MinHeight = 65
            };

            if (string.IsNullOrEmpty(source) == false)
            {
                mediaElement.Source = new Uri(source);
            }

            var width = video.DisplayWidth;
            if (width > 0)
            {
                mediaElement.Width = width;
            }

            var height = video.DisplayHeight;
            if (height > 0)
            {
                mediaElement.Height = height;
            }

            parent.Add(mediaElement);
        }
    }
}