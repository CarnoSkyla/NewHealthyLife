using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyLifeApp.Services.Interfaces
{
    public interface ILoginSecurity
    {
        bool LogIn(string userName, string password);

        void LogOut();
    }
}
