using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace HealthyLifeApp.Models
{
    public class UserInformation
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Hobbies { get; set; }
        [Required]
        public string DietaryRestrictions { get; set; }

        public int Weight { get; set; }
    }
}
