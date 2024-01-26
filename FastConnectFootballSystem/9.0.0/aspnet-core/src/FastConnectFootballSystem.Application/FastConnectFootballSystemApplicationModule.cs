using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FastConnectFootballSystem.Authorization;

namespace FastConnectFootballSystem
{
    [DependsOn(
        typeof(FastConnectFootballSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FastConnectFootballSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FastConnectFootballSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FastConnectFootballSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
