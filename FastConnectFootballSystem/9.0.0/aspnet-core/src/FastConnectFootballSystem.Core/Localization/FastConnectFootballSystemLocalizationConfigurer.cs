using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace FastConnectFootballSystem.Localization
{
    public static class FastConnectFootballSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(FastConnectFootballSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(FastConnectFootballSystemLocalizationConfigurer).GetAssembly(),
                        "FastConnectFootballSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
