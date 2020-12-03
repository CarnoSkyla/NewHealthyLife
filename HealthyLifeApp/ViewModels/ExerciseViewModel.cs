using HealthyLifeApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HealthyLifeApp.ViewModels
{
    public class ExerciseViewModel : BindableBase
    {
        private string _currentTime;
        public string CurrentTime
        {
            get { return _currentTime; }
            set { SetProperty(ref _currentTime, value); }
        }

        private DateTime _startTime;
        public IPageDialogService _pageDialog;


        public Exercises Exercise { get; set; }
       // public Location Location { get; set; }
        public Timer Time { get; set; }

        public Location startLocation;


        public Location endLocation;
        public readonly INavigationService NavigationService;

        private DelegateCommand _GetStartLocation;
        public DelegateCommand StartLocation =>
            _GetStartLocation ?? (_GetStartLocation = new DelegateCommand(ExecuteStartLocation));

        private DelegateCommand _GetEndLocation;
        public DelegateCommand EndLocation =>
            _GetEndLocation ?? (_GetEndLocation = new DelegateCommand(ExecuteEndLocation));

        private DelegateCommand _DistanceTravelled;
        public DelegateCommand GetDistance =>
            _DistanceTravelled ?? (_DistanceTravelled = new DelegateCommand(ExecuteGetDistance));

       

        async void ExecuteEndLocation() {
        
           CurrentTime += DateTime.Now.Minute.ToString();

            var startLocation = new Location(-33, 18);
            var endLocation = new Location(-33, 19);
            var distance = Location.CalculateDistance(startLocation, endLocation, DistanceUnits.Kilometers);

            var endTime = DateTime.Now;

            var elapsedTime = endTime - _startTime;

            CurrentTime = elapsedTime.TotalMinutes.ToString();
            Exercise.Timer = CurrentTime;
            
        }

        async void ExecuteStartLocation() {
        
            var location = await Geolocation.GetLastKnownLocationAsync();

            var latitude = location.Latitude;
            var longitude = location.Longitude;
            startLocation = new Location(latitude, longitude);
            _startTime = DateTime.Now; 
            Device.StartTimer(new TimeSpan(0, 0, 1), TimerTick);
            await _pageDialog.DisplayAlertAsync("Hey", "Your exercise time begins now", "Ok");
        }
       
        public ExerciseViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        {
            NavigationService = navigationService;
            var activity = new Exercises();
            _pageDialog = pageDialog;
            Exercise = activity;

        }

        private bool TimerTick()
        {
            CurrentTime = DateTime.Now.ToString();
            
            return true;
        }
    }
}

