using SoftwareKobo.HtmlRender.Core.ElementRender;
using SoftwareKobo.HtmlRender.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareKobo.HtmlRender.Core
{
    public class ElementRenderContainerBase
    {
        private static ElementRenderContainerBase _defaultElementRenderContainer;

        private readonly Dictionary<string, Type> _renders = new Dictionary<string, Type>();

        static ElementRenderContainerBase()
        {
            Default = new ElementRenderContainerBase();
            Default
                .Register<ARender>()
                .Register<BlockquoteRender>()
                .Register<BrRender>()
                .Register<CenterRender>()
                .Register<CodeRender>()
                .Register<DivRender>()
                .Register<EmRender>()
                .Register<H1Render>()
                .Register<H2Render>()
                .Register<H3Render>()
                .Register<H4Render>()
                .Register<H5Render>()
                .Register<H6Render>()
                .Register<HrRender>()
                .Register<IframeRender>()
                .Register<ImgRender>()
                .Register<LiRender>()
                .Register<ObjectRender>()
                .Register<OlRender>()
                .Register<PRender>()
                .Register<PreRender>()
                .Register<SpanRender>()
                .Register<StrongRender>()
                .Register<TableRender>();
        }

        public static ElementRenderContainerBase Default
        {
            get
            {
                return _defaultElementRenderContainer
                    ;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _defaultElementRenderContainer = value;
            }
        }

        internal Dictionary<string, Type> Renders
        {
            get
            {
                return _renders;
            }
        }

        public virtual bool Contains(string tagName)
        {
            return Renders.Keys.Contains(tagName, StringComparer.OrdinalIgnoreCase);
        }

        public IElementRender GetRender(string tagName)
        {
            var type = (from keyValue in Renders
                        where string.Equals(keyValue.Key, tagName, StringComparison.OrdinalIgnoreCase)
                        select keyValue.Value).FirstOrDefault();
            if (type != null)
            {
                return Activator.CreateInstance(type) as IElementRender;
            }
            return null;
        }

        public ElementRenderContainerBase Register<TRender>() where TRender : IElementRender
        {
            return Register(typeof(TRender));
        }

        public ElementRenderContainerBase Register(Type renderType)
        {
            if (renderType == null)
            {
                throw new ArgumentNullException("renderType");
            }
            var tagRender = Activator.CreateInstance(renderType) as IElementRender;
            if (tagRender == null)
            {
                throw new ArgumentException("renderType is not implement ITagRender interface.", "renderType");
            }
            return Register(tagRender);
        }

        public ElementRenderContainerBase Register(IElementRender tagRender)
        {
            if (tagRender == null)
            {
                throw new ArgumentNullException("tagRender");
            }
            Renders.Add(tagRender.TagName, tagRender.GetType());
            return this;
        }
    }
}