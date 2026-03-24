using System;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositeries;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select storage mechanism:");
            Console.WriteLine("1) In-Memory (List)");
            Console.WriteLine("2) JSON File (persistent)");
            Console.Write("Choice (1/2): ");

            var input = Console.ReadLine();
            if (!int.TryParse(input, out var choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice. Exiting.");
                return;
            }

            IStudentRepository repository = choice == 1
                ? new ListStudentRepository()
                : new JsonStudentRepository();

            IStudentService service = new StudentService(repository);

            RunMenu(service);
        }

        static void RunMenu(IStudentService service)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Create student");
                Console.WriteLine("2) List all students");
                Console.WriteLine("3) View student by Id");
                Console.WriteLine("4) Update student");
                Console.WriteLine("5) Delete student");
                Console.WriteLine("6) Exit");
                Console.Write("Select option: ");

                var opt = Console.ReadLine();
                if (!int.TryParse(opt, out var choice))
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            CreateStudent(service);
                            break;
                        case 2:
                            ListAll(service);
                            break;
                        case 3:
                            ViewById(service);
                            break;
                        case 4:
                            UpdateStudent(service);
                            break;
                        case 5:
                            DeleteStudent(service);
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Unknown option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void CreateStudent(IStudentService service)
        {
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Grade (0-100): ");
            var gradeText = Console.ReadLine();
            if (!int.TryParse(gradeText, out var grade))
            {
                Console.WriteLine("Invalid grade.");
                return;
            }

            var student = service.AddStudent(name, grade);
            Console.WriteLine($"Created: {student}");
        }

        static void ListAll(IStudentService service)
        {
            var list = service.GetAll();
            foreach (var s in list)
            {
                Console.WriteLine(s);
            }
        }

        static void ViewById(IStudentService service)
        {
            Console.Write("Id: ");
            var idText = Console.ReadLine();
            if (!int.TryParse(idText, out var id))
            {
                Console.WriteLine("Invalid id.");
                return;
            }

            var s = service.GetById(id);
            if (s == null) Console.WriteLine("Not found.");
            else Console.WriteLine(s);
        }

        static void UpdateStudent(IStudentService service)
        {
            Console.Write("Id to update: ");
            var idText = Console.ReadLine();
            if (!int.TryParse(idText, out var id))
            {
                Console.WriteLine("Invalid id.");
                return;
            }

            var existing = service.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write($"Name ({existing.Name}): ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) name = existing.Name;

            Console.Write($"Grade ({existing.Grade}): ");
            var gradeText = Console.ReadLine();
            if (!int.TryParse(gradeText, out var grade)) grade = existing.Grade;

            var ok = service.Update(id, name, grade);
            Console.WriteLine(ok ? "Updated." : "Update failed.");
        }

        static void DeleteStudent(IStudentService service)
        {
            Console.Write("Id to delete: ");
            var idText = Console.ReadLine();
            if (!int.TryParse(idText, out var id))
            {
                Console.WriteLine("Invalid id.");
                return;
            }

            var ok = service.Delete(id);
            Console.WriteLine(ok ? "Deleted." : "Not found.");
        }
    }
}