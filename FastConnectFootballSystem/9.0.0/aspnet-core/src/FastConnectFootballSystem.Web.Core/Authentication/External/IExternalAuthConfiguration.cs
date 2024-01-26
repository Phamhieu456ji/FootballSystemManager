using System.Collections.Generic;

namespace FastConnectFootballSystem.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
