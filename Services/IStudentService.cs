using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_eventRegistration.Models;

namespace dotnet_eventRegistration.Services
{
    public interface IStudentService
    {
        Task<String>addStudent(StudentViewModel student);
        Task<IEnumerable<Student>> getAll();
        Task<Student> GetStudent(Guid studentID);

     }
}
