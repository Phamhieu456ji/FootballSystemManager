using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FastConnectFootballSystem.Configuration;
using FastConnectFootballSystem.EntityFrameworkCore;
using FastConnectFootballSystem.Migrator.DependencyInjection;

namespace FastConnectFootballSystem.Migrator
{
    [DependsOn(typeof(FastConnectFootballSystemEntityFrameworkModule))]
    public class FastConnectFootballSystemMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public FastConnectFootballSystemMigratorModule(FastConnectFootballSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(FastConnectFootballSystemMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                FastConnectFootballSystemConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FastConnectFootballSystemMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
