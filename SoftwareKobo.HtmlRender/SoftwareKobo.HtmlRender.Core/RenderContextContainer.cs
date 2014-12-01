using AngleSharp.DOM;
using System;

namespace SoftwareKobo.HtmlRender.Core
{
    public sealed class RenderContextContainer
    {
        private static Type _defaultContext;

        static RenderContextContainer()
        {
            _defaultContext = typeof(RenderContextBase);
        }

        public static RenderContextBase GetInstance(string html)
        {
            return Activator.CreateInstance(_defaultContext, html) as RenderContextBase;
        }

        public static RenderContextBase GetInstance(IDocument document)
        {
            return Activator.CreateInstance(_defaultContext, document) as RenderContextBase;
        }

        public static void SetDefault<T>() where T : RenderContextBase
        {
            _defaultContext = typeof(T);
        }
    }
}