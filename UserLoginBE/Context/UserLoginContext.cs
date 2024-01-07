using GovBE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserLoginBE.Entities.Configurations;
using UserLoginBE.Entities.Models;

namespace UserLoginBE.Context
{
    public class UserLoginContext : IdentityDbContext<UserApp>
    {
        public UserLoginContext(DbContextOptions options)
        : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<UserApp> Users { get; set; } 
    }
}
