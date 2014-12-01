using Windows.UI.Xaml.Documents;
using AngleSharp.DOM;
using System;
using System.Collections.Generic;

namespace SoftwareKobo.HtmlRender.Core.Extension
{
    public static class ElementExtensions
    {
        public static int? Height(this IElement element)
        {
            var height = element.GetAttribute("height");
            return ParsePixelOrPercent(height);
        }

        public static Dictionary<string, string> Style(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            var styleAttribute = element.GetAttribute("style") ?? string.Empty;
            styleAttribute = styleAttribute.Trim();
            if (String.IsNullOrEmpty(styleAttribute))
            {
                return new Dictionary<string, string>();
            }
            var propertyValues = styleAttribute.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var dict = new Dictionary<string, string>();
            foreach (var propertyValue in propertyValues)
            {
                var temp = propertyValue.Trim().Split(':');
                var property = temp[0];
                var value = temp[1];
                dict.Add(property, value);
            }
            return dict;
        }

        public static string Style(this IElement element, string property)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }
            if (string.IsNullOrWhiteSpace(property))
            {
                throw new ArgumentException("property name could not be empty or white space.", "property");
            }

            var dict = Style(element);
            return dict.ContainsKey(property) ? dict[property] : null;
        }

        public static int? Width(this IElement element)
        {
            var width = element.GetAttribute("width");
            return ParsePixelOrPercent(width);
        }

        private static int? ParsePixelOrPercent(string pixelOrPercent)
        {
            if (string.IsNullOrWhiteSpace(pixelOrPercent))
            {
                return null;
            }
            pixelOrPercent = pixelOrPercent.Trim();
            if (pixelOrPercent.EndsWith("%"))
            {
                return null;
            }
            if (pixelOrPercent.EndsWith("px", StringComparison.OrdinalIgnoreCase))
            {
                pixelOrPercent = pixelOrPercent.Substring(0, pixelOrPercent.Length - 2);
            }
            int pixel;
            if (int.TryParse(pixelOrPercent, out pixel))
            {
                return pixel;
            }
            return null;
        }
    }
}