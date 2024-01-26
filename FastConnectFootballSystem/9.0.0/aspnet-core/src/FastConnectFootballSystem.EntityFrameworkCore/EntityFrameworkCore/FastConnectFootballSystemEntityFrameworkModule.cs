using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using FastConnectFootballSystem.EntityFrameworkCore.Seed;

namespace FastConnectFootballSystem.EntityFrameworkCore
{
    [DependsOn(
        typeof(FastConnectFootballSystemCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class FastConnectFootballSystemEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<FastConnectFootballSystemDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        FastConnectFootballSystemDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        FastConnectFootballSystemDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FastConnectFootballSystemEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
