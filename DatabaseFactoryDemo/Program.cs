using Core.Entities;
using Core.Enums;
using DatabaseFactoryDemo.Factory;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose database: 1 = SQL Server, 2 = SQLite, 3 = PostgreSQL");
        var choice = Console.ReadLine();

        DatabaseType dbType = choice switch
        {
            "1" => DatabaseType.SqlServer,
            "2" => DatabaseType.SQLite,
            "3" => DatabaseType.PostgreSQL,
            _ => DatabaseType.SqlServer
        };

        Console.WriteLine("Enter Name of Student: ");
        string name = Console.ReadLine();
        var repo = RepositoryFactory.CreateStudentRepository(dbType);
        repo.Add(new Student { Name = name });

        Console.WriteLine("Student Added Successfully");
    }
}
