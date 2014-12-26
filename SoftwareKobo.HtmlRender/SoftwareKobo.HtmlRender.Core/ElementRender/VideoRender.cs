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

            var mediaElement = new MediaElement
            {
                Source = new Uri(video.Source),
                AreTransportControlsEnabled = true
            };

            parent.Add(mediaElement);
            context.RenderNode(element, parent);
        }
    }
}