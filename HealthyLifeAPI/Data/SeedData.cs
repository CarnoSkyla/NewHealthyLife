
using HealthyLifeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyLifeAPI.Data
{
    public class SeedData
    {
        public static void Initialize(LoginContext context)
        {


            if (!context.LoginDetails.Any())
            {
                context.LoginDetails.AddRange(
                    new LoginInfo
                    {
                        Email = "testing@gmail.com" ,
                        Password = "12345"

                    },
                    new LoginInfo
                    {
                        Email = "test@quirky30.co.za",
                        Password = "123",

                    }
                );

                context.SaveChanges();
            }
        }
    }
}
