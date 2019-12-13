using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthyLifeApp.Models
{
    public class Journal
    {
        [Key]
        public int PostID { get; set; }
        public string Post { get; set; }
    }
}
