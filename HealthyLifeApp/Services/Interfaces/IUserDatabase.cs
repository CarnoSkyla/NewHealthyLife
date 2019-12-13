using HealthyLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifeApp.Services.Interfaces
{
    public interface IUserDatabase
    {
        Task<int> SaveUser(UserInformation user);
        Task<List<UserInformation>> GetUsers();
        Task<int> DeleteUsers();
        Task<UserInformation> GetUserByEmail(string user);
       
    }
}
