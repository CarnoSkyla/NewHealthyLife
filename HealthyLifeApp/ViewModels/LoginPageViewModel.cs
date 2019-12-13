using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using HealthyLifeApp.Services.Interfaces;
using HealthyLifeApp.Models;
using HealthyLifeApp.Services;
using Xamarin.Essentials;
using Prism.Events;
using Newtonsoft.Json;
using System.Net.Http;
using Prism.Services;

namespace HealthyLifeApp.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigatedAware
    {
        

        public readonly INavigationService NavigationService;

        private IUserDatabase userDatabase;
        public UserInformation user;
        public Login Login { get; set; }

        public IPageDialogService _pageDialog;

        private DelegateCommand _toMainPage;
        public DelegateCommand ToMainPage =>
            _toMainPage ?? (_toMainPage = new DelegateCommand(ExecuteToMainPage));

        private DelegateCommand _toSignUpPage;
        public DelegateCommand ToSignUpPage =>
            _toSignUpPage ?? (_toSignUpPage = new DelegateCommand(ExecuteToSignUpPage));

        private DelegateCommand _DeleteUsers;
        public DelegateCommand Delete =>
            _DeleteUsers ?? (_DeleteUsers = new DelegateCommand(ExecuteDelete));

        async void ExecuteDelete()
        {
            userDatabase = new UserDatabase();
            await userDatabase.DeleteUsers();
        }

        async void ExecuteToSignUpPage()
        {
            await NavigationService.NavigateAsync("SignUpPage");

            
        }

         async void ExecuteToMainPage()
        {
            userDatabase = new UserDatabase();
            var users = await userDatabase.GetUsers();

            var user = await userDatabase.GetUserByEmail(Login.Email);
            

            if(user != null)
            {
                var logInfo = new { Email = user.Email, Password = user.Password };

                var json = JsonConvert.SerializeObject(logInfo);
                var uri = "http://10.0.2.2:5000/UserLoginDetails";
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var http = new HttpClient();
                await NavigationService.NavigateAsync("MainPage");
                

                try
                {

                    var post = await http.PostAsync(uri, content);

                    await _pageDialog.DisplayAlertAsync("Hey There", post.ReasonPhrase, "Okay");
                    
                }
                catch(Exception ex)
                {
                    await _pageDialog.DisplayAlertAsync("Hey There", ex.Message, "Ok");
                }
            }
            else
            {
                await _pageDialog.DisplayAlertAsync("Hey There", "Current User doesn't exist", "Ok");
                Login = new Login();
            }

        }
            

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            var weight = parameters.GetValue<UserInformation>("Weight");
            var dietaryRestriction = parameters.GetValue<UserInformation>("DietaryRestriction");
        
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            user = parameters["email"] as UserInformation; 
        
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        {
            NavigationService = navigationService;
            var userLoginDetails = new Login();
            Login = userLoginDetails;
            _pageDialog = pageDialog;
            

        }

        
    }
}
