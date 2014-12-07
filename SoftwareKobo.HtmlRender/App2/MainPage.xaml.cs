﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍
using SoftwareKobo.CnblogsAPI.Service;

namespace App2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page,INotifyPropertyChanged
    {
        private string _hh;

        public string HH
        {
            get { return _hh; }
            set { _hh = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this,new PropertyChangedEventArgs("HH"));
                }
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = this;
        }

        private int id = 509877;

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ff.Navigate(new Uri("http://player.pps.tv/player/sid/3FSZWC/v.swf"));

            var detail = (await NewsService.DetailAsync(id));

            HH = detail.Content;
            id = detail.PrevNews.Value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
