using System;

namespace StudentManagementSystem.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Grade { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Grade: {Grade}";
    }
}