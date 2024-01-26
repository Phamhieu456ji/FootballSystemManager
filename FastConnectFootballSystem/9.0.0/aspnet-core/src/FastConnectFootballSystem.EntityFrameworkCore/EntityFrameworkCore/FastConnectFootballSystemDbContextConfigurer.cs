using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FastConnectFootballSystem.EntityFrameworkCore
{
    public static class FastConnectFootballSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FastConnectFootballSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FastConnectFootballSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
