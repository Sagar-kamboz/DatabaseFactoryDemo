using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFactoryDemo.Infrastructure.Factories
{
    public class PostgreDbContextFactory : IDesignTimeDbContextFactory<PostgreDbContext>
    {
        public PostgreDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PostgreSQL");

            var optionsBuilder = new DbContextOptionsBuilder<PostgreDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new PostgreDbContext(optionsBuilder.Options);
        }
    }
}
