using MVCPro.Models;
using System.Collections.Generic;

namespace MVCPro.Services
{
    public class StudentService : IStudentService
    {
        private static List<StudentModel> _students = new List<StudentModel>();

        public List<StudentModel> GetStudentData() => _students;

        public void AddStudent(StudentModel student) => _students.Add(student);
    }
}