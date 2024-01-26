using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FastConnectFootballSystem.Configuration;
using FastConnectFootballSystem.Web;

namespace FastConnectFootballSystem.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FastConnectFootballSystemDbContextFactory : IDesignTimeDbContextFactory<FastConnectFootballSystemDbContext>
    {
        public FastConnectFootballSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FastConnectFootballSystemDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FastConnectFootballSystemDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FastConnectFootballSystemConsts.ConnectionStringName));

            return new FastConnectFootballSystemDbContext(builder.Options);
        }
    }
}
