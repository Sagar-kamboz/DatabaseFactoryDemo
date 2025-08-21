using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatabaseFactoryDemo.Factory
{
    public static class RepositoryFactory
    {
        private static IConfigurationRoot LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // or AppContext.BaseDirectory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static IRepository<Student> CreateStudentRepository(DatabaseType dbType)
        {
            var config = LoadConfiguration();

            switch (dbType)
            {
                case DatabaseType.SqlServer:
                    {
                        var conn = config.GetConnectionString("SqlServer");
                        var options = new DbContextOptionsBuilder<SqlServerDbContext>()
                                          .UseSqlServer(conn)
                                          .Options;
                        var ctx = new SqlServerDbContext(options);
                        return new DatabaseFactoryDemo.Infrastructure.Repositories.SQLServer.StudentRepository(ctx);
                    }

                case DatabaseType.SQLite:
                    {
                        var conn = config.GetConnectionString("SQLite");
                        var options = new DbContextOptionsBuilder<SqliteDbContext>()
                                          .UseSqlite(conn)
                                          .Options;
                        var ctx = new SqliteDbContext(options);
                        return new DatabaseFactoryDemo.Infrastructure.Repositories.SQLite.StudentRepository(ctx);
                    }

                case DatabaseType.PostgreSQL:
                    {
                        var conn = config.GetConnectionString("PostgreSQL");
                        var options = new DbContextOptionsBuilder<PostgreDbContext>()
                                          .UseNpgsql(conn)
                                          .Options;
                        var ctx = new PostgreDbContext(options);
                        return new DatabaseFactoryDemo.Infrastructure.Repositories.PostgreSQL.StudentRepository(ctx);
                    }

                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
