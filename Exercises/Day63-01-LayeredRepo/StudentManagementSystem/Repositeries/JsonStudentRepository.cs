using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositeries
{
    internal class JsonStudentRepository : IStudentRepository
    {
        private readonly string filePath;
        private readonly object fileLock = new();

        public JsonStudentRepository()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "StudentManagementSystem");
            Directory.CreateDirectory(dir);
            filePath = Path.Combine(dir, "students.json");
        }

        private List<Student> Load()
        {
            lock (fileLock)
            {
                if (!File.Exists(filePath)) return new List<Student>();
                var json = File.ReadAllText(filePath);
                if (string.IsNullOrWhiteSpace(json)) return new List<Student>();
                return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
        }

        private void Save(List<Student> students)
        {
            lock (fileLock)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(students, options);
                File.WriteAllText(filePath, json);
            }
        }

        public void AddStudent(Student student)
        {
            var list = Load();
            list.Add(student);
            Save(list);
        }

        public IEnumerable<Student> GetAll()
        {
            return Load();
        }

        public Student? GetById(int id)
        {
            return Load().FirstOrDefault(s => s.Id == id);
        }

        public bool Update(Student student)
        {
            var list = Load();
            var index = list.FindIndex(s => s.Id == student.Id);
            if (index < 0) return false;
            list[index] = student;
            Save(list);
            return true;
        }

        public bool Delete(int id)
        {
            var list = Load();
            var removed = list.RemoveAll(s => s.Id == id) > 0;
            if (removed) Save(list);
            return removed;
        }
    }
}