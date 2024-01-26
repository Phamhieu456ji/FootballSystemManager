using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using FastConnectFootballSystem.Authorization.Roles;
using FastConnectFootballSystem.Authorization.Users;
using FastConnectFootballSystem.Configuration;
using FastConnectFootballSystem.Localization;
using FastConnectFootballSystem.MultiTenancy;
using FastConnectFootballSystem.Timing;

namespace FastConnectFootballSystem
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class FastConnectFootballSystemCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            FastConnectFootballSystemLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = FastConnectFootballSystemConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = FastConnectFootballSystemConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = FastConnectFootballSystemConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FastConnectFootballSystemCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
