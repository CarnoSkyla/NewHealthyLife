using HealthyLifeApp.Models;
using HealthyLifeApp.Services;
using HealthyLifeApp.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace HealthyLifeApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public List<Schedule> ScheduleProperty { get; set; }
        public IPageDialogService _pageDialog;
        public IUserDatabase userDatabase;

        public UserInformation UserInformation { get; set; }
        public readonly INavigationService NavigationService;
        private DelegateCommand _toExercise;
        public DelegateCommand ToExercise =>
            _toExercise ?? (_toExercise = new DelegateCommand(ExecuteToExercise));

        private DelegateCommand _ToArticles;
        public DelegateCommand Articles =>
            _ToArticles ?? (_ToArticles = new DelegateCommand(ExecuteArticles));

        private DelegateCommand _logout;
        public DelegateCommand Logout =>
            _logout ?? (_logout = new DelegateCommand(ExecuteLogout));

        private DelegateCommand _toJournal;
        public DelegateCommand ToJournal =>
            _toJournal ?? (_toJournal = new DelegateCommand(ExecuteToJournal));

        async void ExecuteToJournal()
        {
            await NavigationService.NavigateAsync("Journal");
        }

        async void ExecuteLogout()
        {
            bool askUser = await _pageDialog.DisplayAlertAsync("Logout", "Are you sure you want to logout?", "Ok", "Cancel");

            if(askUser == true)
            {
                await NavigationService.NavigateAsync("SignUpPage");
            }
        }


        async void ExecuteArticles()
        {
            await NavigationService.NavigateAsync("Articles");
        }

        async void ExecuteToExercise()
        {
            await NavigationService.NavigateAsync("Exercise");
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialog)
            : base(navigationService)
        {
            Title = "Main Page";
            NavigationService = navigationService;
            var connectivity = Connectivity.NetworkAccess;
            
            _pageDialog = pageDialog;

            var datetime = DateTime.Now;
            var userDetails = new UserInformation();
            UserInformation = userDetails;
            UserInformation.Date = datetime.Date.ToString().Substring(0, 10);
            UserInformation.Name = "Sibusiso";

            var taskTime = string.Empty;

            taskTime = datetime.Hour.ToString() + " : " + datetime.Minute.ToString();


             ScheduleProperty = new List<Schedule>
           {

               new Schedule{
                   Task = "Have BreakFast",
                   TaskDetails = "Meal",
                   TaskIcon = "task.png",
                   Time = taskTime
               },
               new Schedule
               {
                   Task = "Exercise Time",
                   TaskDetails = "Run",
                   TaskIcon = "task.png",
                   Time = taskTime
               }
           };



        }

        public async override void Initialize(INavigationParameters parameters)
        {

            userDatabase = new UserDatabase();
            var users = await userDatabase.GetUsers();
        }
    }
}
