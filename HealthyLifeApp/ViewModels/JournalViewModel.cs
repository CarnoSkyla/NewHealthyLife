using HealthyLifeApp.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HealthyLifeApp.ViewModels
{
    public class JournalViewModel : BindableBase
    {
        public readonly INavigationService NavigationService;
        public IPageDialogService _pageDialog;
        public Journal JournalPosts { get; set; }

        private DelegateCommand _savePost;
        public DelegateCommand SavePost =>
            _savePost ?? (_savePost = new DelegateCommand(ExecuteSavePost));

        void ExecuteSavePost()
        {
            var postInfo = new { Post = JournalPosts.Post };
            var json = JsonConvert.SerializeObject(postInfo);
            var uri = "http://10.0.2.2:5000/UserLoginDetails";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var http = new HttpClient();

            //var postToApi = htt
        }
        public JournalViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        {
            NavigationService = navigationService;
            _pageDialog = pageDialog;
            var post = new Journal();
            JournalPosts = post;
        }
    }
}
