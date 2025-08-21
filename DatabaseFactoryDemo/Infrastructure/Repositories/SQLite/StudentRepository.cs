using Core.Entities;
using Core.Interfaces;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFactoryDemo.Infrastructure.Repositories.SQLite
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SqliteDbContext _context;

        public StudentRepository(SqliteDbContext context)
        {
            _context = context;
        }
        //public void Add(Student entity)
        //{
        //    Console.WriteLine($"[SQLite Server] Student '{entity.Name}' added.");
        //}
        public void Add(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }
    }
}
