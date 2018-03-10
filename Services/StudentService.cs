using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_eventRegistration.Models;
using dotnet_eventRegistration.Data;

namespace dotnet_eventRegistration.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> addStudent(StudentViewModel student)
        {
            var newStudent = new Student
            {
                Id = new Guid(),
                Name = student.Name,
                RollNo = student.RollNo,
                FathersName = student.FathersName,
                BirthDate = student.BirthDate,
                Email = student.Email,
                Phone = student.Phone,
                Address = student.Address,
                EduQualification = student.EduQualification
            };

            _context.Add(newStudent);

            var result = await _context.SaveChangesAsync();

            return result == 1 ;

        }

        public async Task<IEnumerable<Student>> getAll()
        {
            return _context.Students.ToList();

        }
    }
}
