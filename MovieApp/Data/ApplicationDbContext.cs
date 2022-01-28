using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Models;

namespace MovieApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieApp.Models.MovieData> MovieData { get; set; }
        public DbSet<MovieApp.Models.Reviews> Reviews { get; set; }
        public DbSet<MovieApp.Models.PersonalCollection> PersonalCollection { get; set; }
    }
}
