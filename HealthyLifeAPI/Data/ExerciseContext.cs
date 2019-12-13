using HealthyLifeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyLifeAPI.Data
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options)
            : base(options)
        {
        }

        public DbSet<Exercises> ExerciseDetails { get; set; }
    }
}
