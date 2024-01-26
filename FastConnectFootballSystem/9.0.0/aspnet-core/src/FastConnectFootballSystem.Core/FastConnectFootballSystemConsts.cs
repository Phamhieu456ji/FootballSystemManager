using FastConnectFootballSystem.Debugging;

namespace FastConnectFootballSystem
{
    public class FastConnectFootballSystemConsts
    {
        public const string LocalizationSourceName = "FastConnectFootballSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "df4cf06502ab40989e2f8dd735c099c5";
    }
}
