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

namespace HealthyLifeApp.ViewModels
{
    public class SignUpPageViewModel : BindableBase
    {
        private IUserDatabase userDatabase;
        public IPageDialogService _pageDialog;
        public UserInformation UserInformation { get; set; }
        public UserInformation user;
        public readonly INavigationService NavigationService;

        private DelegateCommand _saveUser;
        public DelegateCommand SaveUser =>
            _saveUser ?? (_saveUser = new DelegateCommand(ExecuteSaveUser));

        async void ExecuteSaveUser()
        {
            userDatabase = new UserDatabase();
            
            if(UserInformation.Password != UserInformation.ConfirmPassword)
            {
                try
                {
                    await _pageDialog.DisplayAlertAsync("Hey There", "Passwords dont match", "Okay");
                }
                catch (Exception ex)
                {

                    await _pageDialog.DisplayAlertAsync($"Hey {UserInformation.Name}", ex.Message, "Ok");
                }
                
                UserInformation = new UserInformation();
            }
            else
            {
                var navParameters = new NavigationParameters();
                navParameters.Add("user", UserInformation);
                await userDatabase.SaveUser(UserInformation);
                await _pageDialog.DisplayAlertAsync($"Hey {UserInformation.Name}", "You have successfully signed up", "Ok");
                await NavigationService.NavigateAsync("LoginPage", navParameters);
            }
           
        }
       
        public SignUpPageViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        {
            NavigationService = navigationService;
            var userDetails = new UserInformation();
            UserInformation = userDetails;
            _pageDialog = pageDialog;
        }
    }
}
