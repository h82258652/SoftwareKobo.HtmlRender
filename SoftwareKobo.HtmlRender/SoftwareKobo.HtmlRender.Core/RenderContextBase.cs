using AngleSharp;
using AngleSharp.DOM;
using SoftwareKobo.HtmlRender.Core.Interface;
using SoftwareKobo.HtmlRender.Core.TextContainer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace SoftwareKobo.HtmlRender.Core
{
    public class RenderContextBase
    {
        private readonly IDocument _document;

        private readonly Stack<string> _tagStack;

        protected internal Stack<string> TagStack
        {
            get
            {
                return _tagStack;
            }
        }

        public RenderContextBase(IDocument document)
            : this()
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }
            _document = document;
        }

        public RenderContextBase(string html)
            : this(DocumentBuilder.Html(html))
        {
        }

        public RenderContextBase()
        {
            _tagStack = new Stack<string>();
            ElementRenders = ElementRenderContainerBase.Default;
        }

        public IDocument Document
        {
            get
            {
                return _document;
            }
        }

        public ElementRenderContainerBase ElementRenders
        {
            get;
            private set;
        }

        public void Render(RichTextBlock richTextBlock)
        {
            if (richTextBlock == null)
            {
                throw new ArgumentNullException("richTextBlock");
            }
            richTextBlock.Blocks.Clear();
            RenderNode(Document.Body, new RichTextBlockContainer(richTextBlock));
        }

        public void Render(Border border)
        {
            if (border == null)
            {
                throw new ArgumentNullException("border");
            }
            var richTextBlock = new RichTextBlock();
            border.Child = richTextBlock;
            Render(richTextBlock);
        }

        public void Render(Panel panel)
        {
            if (panel == null)
            {
                throw new ArgumentNullException("panel");
            }
            var richTextBlock = new RichTextBlock();
            panel.Children.Clear();
            panel.Children.Add(richTextBlock);
            Render(richTextBlock);
        }

        public void RenderNode(INode node, ITextContainer parentContainer)
        {
            var element = node as IElement;
            if (element != null)
            {
                PushTag(element);
                foreach (var child in node.ChildNodes)
                {
                    if (child is IText)
                    {
                        var text = child.TextContent ?? string.Empty;

                        if (TagStack.Contains("pre", StringComparer.OrdinalIgnoreCase) == false)
                        {
                            // Not in pre, replace all line break to empty.
                            text = text.Replace("\r", string.Empty).Replace("\n", string.Empty);
                        }

                        if (string.IsNullOrEmpty(text) == false)
                        {
                            parentContainer.Add(new Run
                            {
                                Text = text
                            });
                        }
                    }
                    else
                    {
                        var childElement = child as IElement;
                        if (childElement != null)
                        {
                            var elementRender = ElementRenders.GetRender(childElement.TagName);
                            if (elementRender != null)
                            {
                                elementRender.RenderElement(childElement, parentContainer, this);
                            }
                            else
                            {
                                Debugger.Break();
                            }
                        }
                    }
                }
                PopTag(element);
            }
        }

        protected virtual void PopTag(IElement element)
        {
            PopTag(element.TagName);
        }

        protected virtual void PopTag(string tag)
        {
            var pop = TagStack.Pop();
            if (pop != tag)
            {
                throw new ArgumentException(string.Format("stack top tag {0} is different with {1}.", pop, tag), "tag");
            }
        }

        protected virtual void PopTag()
        {
            TagStack.Pop();
        }

        protected virtual void PushTag(IElement element)
        {
            PushTag(element.TagName);
        }

        protected virtual void PushTag(string tag)
        {
            TagStack.Push(tag);
        }
    }
}