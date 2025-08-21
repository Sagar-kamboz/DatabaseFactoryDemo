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
    public class SqliteDbContextFactory : IDesignTimeDbContextFactory<SqliteDbContext>
    {
        public SqliteDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SqliteConnection");

            var optionsBuilder = new DbContextOptionsBuilder<SqliteDbContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new SqliteDbContext(optionsBuilder.Options);
        }
    }
}
