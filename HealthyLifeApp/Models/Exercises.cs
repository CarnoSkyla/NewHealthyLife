using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Xamarin.Essentials;

namespace HealthyLifeApp.Models
{
    public class Exercises
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Timer { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
    }
}
