SoftwareKobo.HtmlRender
=======================

Html Render for WinRT or more platform(maybe)

##How to use?##

1.Get it on nuget:
https://www.nuget.org/packages/SoftwareKobo.HtmlRender.WinRT/
<br/>
2.Edit your xaml
<pre><code>
  ...
  xmlns:core="using:SoftwareKobo.HtmlRender.Core"
  ...
  <RichTextBlock core:HtmlRenderHelper.Html="{Binding YourPropertyName}"></RichTextBlock>
</code></pre>
