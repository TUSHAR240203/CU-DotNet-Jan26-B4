using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositeries
{
    internal class ListStudentRepository : IStudentRepository
    {
        private static readonly List<Student> students = new();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public IEnumerable<Student> GetAll()
        {
            // return a copy to avoid external modification
            return students.ToList();
        }

        public Student? GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public bool Update(Student student)
        {
            var existing = GetById(student.Id);
            if (existing == null) return false;
            existing.Name = student.Name;
            existing.Grade = student.Grade;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null) return false;
            return students.Remove(existing);
        }
    }
}