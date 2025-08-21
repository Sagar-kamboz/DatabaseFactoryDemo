using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using DatabaseFactoryDemo.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFactoryDemo.Services
{
    public class StudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(DatabaseType dbType)
        {
            _studentRepository = RepositoryFactory.CreateStudentRepository(dbType);
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

    }
}
