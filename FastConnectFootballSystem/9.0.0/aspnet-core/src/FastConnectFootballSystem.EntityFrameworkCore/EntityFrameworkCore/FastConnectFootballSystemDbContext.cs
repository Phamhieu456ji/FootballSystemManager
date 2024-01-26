using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FastConnectFootballSystem.Authorization.Roles;
using FastConnectFootballSystem.Authorization.Users;
using FastConnectFootballSystem.MultiTenancy;
using FastConnectFootballSystem.Fields;

namespace FastConnectFootballSystem.EntityFrameworkCore
{
    public class FastConnectFootballSystemDbContext : AbpZeroDbContext<Tenant, Role, User, FastConnectFootballSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Field> Fields { get; set; }
        
        public FastConnectFootballSystemDbContext(DbContextOptions<FastConnectFootballSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastConnectFootballSystemDbContext).Assembly);
        }
    }
}
