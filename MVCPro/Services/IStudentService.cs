using MVCPro.Models;
using System.Collections.Generic;

namespace MVCPro.Services
{
    public interface IStudentService
    {
        List<StudentModel> GetStudentData();
        void AddStudent(StudentModel student);
    }
}