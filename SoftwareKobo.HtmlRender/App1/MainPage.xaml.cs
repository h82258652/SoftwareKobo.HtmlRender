using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍
using SoftwareKobo.CnblogsAPI.Service;
using SoftwareKobo.HtmlRender.Core;

namespace App1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: 准备此处显示的页面。

            // TODO: 如果您的应用程序包含多个页面，请确保
            // 通过注册以下事件来处理硬件“后退”按钮:
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed 事件。
            // 如果使用由某些模板提供的 NavigationHelper，
            // 则系统会为您处理该事件。
        }

        private int id = 508419;

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var news = await NewsService.DetailAsync(id);
            B.Content = news.Id;
            T.Text = news.Title;
          //  var detail = news.Content;

            var detail =
                "@Zoonware<br/><fieldset class=\"comment_quote\"><legend>引用</legend>可是据说库存不是这样计算的，每个区段都会预留有一些票，并不需要这样动态的去减库存。</fieldset><br/>请注意，是前淘宝工程师，也就是说，只是个码农而已，不是架构师，甚至是否资深也不知道，再者说了，或许Y根本就没抢过春运票也未可知啊。（否则怎会不知每个站都有指定预留车厢的说法呢）";
                
            //    +"<select>" +
            //    "<option>a</option>" +
            //    "<option>b</option>" +
            //    "<option>b</option>" +
            //    "<option>b</option>" +
            //    "<option>b</option>" +
            //    "</select>" +
            //    "ffffffffffffffff<b>wwwwwwwwwwww</b>";

            HtmlRenderHelper.SetHtml(R, detail);


            id = news.PrevNews.Value;
        }
    }
}
