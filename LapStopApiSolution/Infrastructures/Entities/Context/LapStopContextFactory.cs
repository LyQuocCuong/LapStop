using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Entities.Context
{
    public sealed class LapStopContextFactory : IDesignTimeDbContextFactory<LapStopContext>
    {
        // Define the DbContext was created at the DESIGN-TIME
        // Install 2 packages:
        // Microsoft.Extensions.Configuration.FileExtensions    --> SetBasePath()
        // Microsoft.Extensions.Configuration.Json              --> AddJsonFile()
        public LapStopContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../MainHosts/LapStopApiHost"))    // Combine Path
                .AddJsonFile("appsettings.Development.json")                                    // fileName contains ConnectionString
                .Build();

            var builder = new DbContextOptionsBuilder<LapStopContext>()
                            .UseSqlServer(config.GetConnectionString("LapStopConnection"),      // name of ConnectionString
                                          m => m.MigrationsAssembly("Entities"));    // where running Migration commands on 

            return new LapStopContext(builder.Options);     // define LapStopContext Constructor receive this Object
        }
    }
}
