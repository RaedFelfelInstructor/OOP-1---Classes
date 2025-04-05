
namespace OOP_1___Classes
{
    class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }

        public Student(string name, string id, string mobileNumber, string email)
        {
            Name = name;
            Id = id;
            MobileNumber = mobileNumber;
            Email = email;  
        }

        public override string ToString()
        {
            return $"{Name} | {Id} | {MobileNumber} | {Email}";
        }
    }

    internal class Program
    {

        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": ViewAllStudents(); break;
                    case "3": UpdateStudent(); break;
                    case "4": DeleteStudent(); break;
                    case "5": exit = true; break;
                    default: Console.WriteLine("Inval;id choice. Please trye again."); break;
                }
            }
        }

        private static void DeleteStudent()
        {
            ViewAllStudents();

            if (students.Count == 0) return;

            Console.Write("\nEnter the index to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= students.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            students.RemoveAt(index);

            Console.WriteLine("Student deleted successfully!");
        }

        private static void UpdateStudent()
        {
            ViewAllStudents();

            if (students.Count == 0) return;

            Console.Write("\nEnter the index to update: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= students.Count) {
                Console.WriteLine("Invalid index.");
                return;
            }

            var student = students[index];
            Console.WriteLine("Leave blank if you don't want to update a field.");

            Console.Write($"Current name: {student.Name}. New name: ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) student.Name = name;

            Console.Write($"Current ID: {student.Id}. New ID: ");
            var id = Console.ReadLine();
            if (!string.IsNullOrEmpty(id)) student.Id = id;

            Console.Write($"Current mobile: {student.MobileNumber}. New mobile: ");
            var mobile = Console.ReadLine();
            if (!string.IsNullOrEmpty(mobile)) student.MobileNumber = mobile;

            Console.Write($"Current mobile: {student.Email}. New mobile: ");
            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) student.Email = mobile;

            Console.WriteLine("Student updated successfully!");
        }

        private static void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\nAll Students:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Index | Name | ID | Mobile Number | Eamil");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i} | {students[i]} ");
            }
        }

        private static void AddStudent()
        {
            
            Console.Write("Enter student name: "); var name = Console.ReadLine();
            Console.Write("Enter student ID: "); var id = Console.ReadLine();
            Console.Write("Enter student mobile: "); var mobile = Console.ReadLine();
            Console.Write("Enter student Email: "); var email = Console.ReadLine();

            var newStudent = new Student(name, id, mobile, email);
            students.Add(newStudent);

            Console.WriteLine("Student added successfully!");
        }
    }
}
