using AngleSharp.DOM;
using AngleSharp.DOM.Html;
using SoftwareKobo.HtmlRender.Core.Extension;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace SoftwareKobo.HtmlRender.Core.ElementRender
{
    public class ImgRender : IElementRender
    {
        public string TagName
        {
            get
            {
                return "img";
            }
        }

        public virtual void RenderElement(IElement element, ITextContainer parent, RenderContextBase context)
        {
            var img = (IHtmlImageElement)element;
            var source = img.Source;
            if (string.IsNullOrEmpty(source))
            {
                return;
            }

            var image = new Image
            {
                Source = new BitmapImage(new Uri(source, UriKind.Absolute))
            };

            double scale = 1.0;

            int? width = img.Width();
            if (width.HasValue)
            {
                if (width.Value > Window.Current.Bounds.Width - 40)
                {
                    scale = (Window.Current.Bounds.Width - 40) / width.Value;
                }

                image.Width = width.Value * scale;
            }
            int? height = img.Height();
            if (height.HasValue)
            {
                image.Height = height.Value * scale;
            }

            DisplayInformation.GetForCurrentView().OrientationChanged +=
                (DisplayInformation sender, object args) =>
                {
                    if (sender.CurrentOrientation == DisplayOrientations.Portrait)
                    {
                        double scale1 = 1.0;

                        int? width1 = img.Width();
                        if (width1.HasValue)
                        {
                            if (width1.Value > Window.Current.Bounds.Width - 40)
                            {
                                scale1 = (Window.Current.Bounds.Width - 40) / width1.Value;
                            }

                            image.Width = width1.Value * scale1;
                        }
                        int? height1 = img.Height();
                        if (height1.HasValue)
                        {
                            image.Height = height1.Value * scale1;
                        }
                    }
                    else if (sender.CurrentOrientation == DisplayOrientations.Landscape || sender.CurrentOrientation == DisplayOrientations.LandscapeFlipped)
                    {
                        double scale1 = 1.0;

                        int? width1 = img.Width();
                        if (width1.HasValue)
                        {
                            if (width1.Value > Window.Current.Bounds.Width - 40)
                            {
                                scale1 = (Window.Current.Bounds.Width - 40) / width1.Value;
                            }

                            image.Width = width1.Value * scale1;
                        }
                        int? height1 = img.Height();
                        if (height1.HasValue)
                        {
                            image.Height = height1.Value * scale1;
                        }
                    }
                };

            parent.Add(image);
        }
    }
}