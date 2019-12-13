using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace HealthyLifeApp.ViewModels
{
    public class ArticlesViewModel : BindableBase
    {
        public readonly INavigationService NavigationService;
        public WebView ContentPage { get; private set; }

        private string _contentUrl;
        public string ContentUrl
        {
            get { return _contentUrl; }
            set { SetProperty(ref _contentUrl, value); }
        }


        public ArticlesViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;



            // var web = new WebView();

            // ContentPage = web;
            // ContentPage.Source = "https://www.eufic.org/en/healthy-living/article/10-healthy-lifestyle-tips-for-adults";


            ContentUrl = "https://www.eufic.org/en/healthy-living/article/10-healthy-lifestyle-tips-for-adults";
        }
    }
}
