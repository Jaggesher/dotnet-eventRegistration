﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_eventRegistration.Models;
using dotnet_eventRegistration.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_eventRegistration.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<String> addStudent(StudentViewModel student)
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

            _context.Students.Add(newStudent);

            var result = await _context.SaveChangesAsync();
            String Id= newStudent.Id.ToString();

            if(result == 1) return Id;
            
            return null;

        }

        public async Task<IEnumerable<Student>> getAll()
        {
            return await _context.Students.ToArrayAsync();

        }

        public async Task<Student> GetStudent(Guid studentID)
        {
            return await _context.Students.Where(X => X.Id == studentID).SingleAsync();
        }
    }
}
