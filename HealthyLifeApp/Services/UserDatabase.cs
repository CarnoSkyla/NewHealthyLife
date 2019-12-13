using HealthyLifeApp.Models;
using HealthyLifeApp.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Essentials;

namespace HealthyLifeApp.Services
{
    public class UserDatabase : IUserDatabase, IExercise
    {
        private SQLiteAsyncConnection userDB;

        public UserDatabase()
        {
            string dbpath = GetDbPath();
            userDB = new SQLiteAsyncConnection(dbpath);
            userDB.CreateTableAsync<UserInformation>().Wait();
            userDB.CreateTableAsync<Exercises>().Wait();
        }



        public Task<int> SaveUser(UserInformation user)
        {
            return userDB.InsertAsync(user);
        }
        public async Task<UserInformation> GetUserByEmail(string email)
        {
            return await userDB.Table<UserInformation>().Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public Task<List<UserInformation>> GetUsers()
        {
            return userDB.Table<UserInformation>().ToListAsync();
        }
        public async Task<int> DeleteUsers()
        {
            return await userDB.DeleteAllAsync<UserInformation>();
        }


        public Task<int> SaveActivity(Exercises exercise)
        {
            return userDB.InsertAsync(exercise);
        }
        public Task<List<Exercises>> GetActivity()
        {
            return userDB.Table<Exercises>().ToListAsync();
        }
        
        private string GetDbPath()

        {

            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");

        }

        
    }
}
