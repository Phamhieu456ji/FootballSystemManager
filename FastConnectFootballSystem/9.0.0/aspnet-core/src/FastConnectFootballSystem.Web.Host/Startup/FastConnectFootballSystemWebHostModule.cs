using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FastConnectFootballSystem.Configuration;

namespace FastConnectFootballSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(FastConnectFootballSystemWebCoreModule))]
    public class FastConnectFootballSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FastConnectFootballSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FastConnectFootballSystemWebHostModule).GetAssembly());
        }
    }
}
