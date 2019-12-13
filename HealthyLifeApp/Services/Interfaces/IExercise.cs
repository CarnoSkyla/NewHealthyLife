using HealthyLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifeApp.Services.Interfaces
{
    public interface IExercise
    {
        Task<int> SaveActivity(Exercises exercise);
        Task<List<Exercises>> GetActivity();
    }
}
