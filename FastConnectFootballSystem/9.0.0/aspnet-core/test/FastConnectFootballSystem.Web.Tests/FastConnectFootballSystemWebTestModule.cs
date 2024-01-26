using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FastConnectFootballSystem.EntityFrameworkCore;
using FastConnectFootballSystem.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace FastConnectFootballSystem.Web.Tests
{
    [DependsOn(
        typeof(FastConnectFootballSystemWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FastConnectFootballSystemWebTestModule : AbpModule
    {
        public FastConnectFootballSystemWebTestModule(FastConnectFootballSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FastConnectFootballSystemWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FastConnectFootballSystemWebMvcModule).Assembly);
        }
    }
}