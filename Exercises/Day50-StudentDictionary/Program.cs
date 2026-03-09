using System;
using System.Collections.Generic;

namespace Week9ClassPractice
{
    class Student
    {
        public int StudentID { get; set; }
        public string SName { get; set; }

        public static Dictionary<Student, int> demo = new Dictionary<Student, int>();

        public override bool Equals(object obj)
        {
            Student stemp = obj as Student;
            if (stemp == null)
            {
                return false;
            }

            return this.StudentID == stemp.StudentID && this.SName == stemp.SName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StudentID, SName);
        }
    }

    internal class Program
    {
        static Dictionary<Student, int> AddStudent(Student student, int marks)
        {
            if (!Student.demo.ContainsKey(student))
            {
                Student.demo.Add(student, marks);
            }
            else
            {
                if (Student.demo[student] < marks)
                {
                    Student.demo[student] = marks;
                }
            }

            return Student.demo;
        }

        static void DisplayRecords()
        {
            foreach (var i in Student.demo)
            {
                Console.WriteLine($"{i.Key.StudentID} {i.Key.SName} {i.Value}");
            }
        }

        static void Main(string[] args)
        {
            Student s1 = new Student { StudentID = 1, SName = "Tushar" };
            Student s2 = new Student { StudentID = 2, SName = "A1" };
            Student s3 = new Student { StudentID = 3, SName = "B1" };
            Student s4 = new Student { StudentID = 3, SName = "B1" };

            AddStudent(s1, 65);
            AddStudent(s2, 95);
            AddStudent(s3, 76);
            AddStudent(s4, 31);

            DisplayRecords();

            AddStudent(s1, 95);
            AddStudent(s2, 95);
            AddStudent(s3, 49);
            AddStudent(s4, 36);

            DisplayRecords();
        }
    }
}