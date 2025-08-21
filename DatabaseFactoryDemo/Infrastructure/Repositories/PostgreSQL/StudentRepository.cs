using Core.Entities;
using Core.Interfaces;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFactoryDemo.Infrastructure.Repositories.PostgreSQL
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly PostgreDbContext _context;

        public StudentRepository(PostgreDbContext context)
        {
            _context = context;
        }

        public void Add(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }
    }
}
