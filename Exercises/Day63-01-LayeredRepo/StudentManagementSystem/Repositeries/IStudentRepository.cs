using System.Collections.Generic;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositeries
{
    internal interface IStudentRepository
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        bool Update(Student student);
        bool Delete(int id);
    }
}