using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class AudioRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "audio";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var audio = (IHtmlAudioElement)element;

            var mediaElement = new MediaElement
            {
                Source = new Uri(audio.Source),
                AreTransportControlsEnabled = true,
                MinHeight = 65
            };

            parent.Add(mediaElement);
            context.RenderNode(element, parent);
        }
    }
}