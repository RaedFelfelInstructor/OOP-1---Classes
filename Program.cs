
namespace OOP_1___Classes
{
    internal class Program
    {

        static string[] studentNames = new string[100];
        static string[] studentIds = new string[100];
        static string[] studentMobileNumbers = new string[100];
        static string[] studentEmails = new string[100];

        static int studentCount = 0;

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

            if (studentCount == 0) return;

            Console.Write("\nEnter the index to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= studentCount)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            // shift all elements after the deleted index
            for (int i = index; i < studentCount - 1; i++)
            {
                studentNames[i] = studentNames[i + 1];
                studentIds[i] = studentIds[i + 1];
                studentMobileNumbers[i] = studentMobileNumbers[i + 1];
                studentEmails[i] = studentEmails[i + 1];
            }

            studentCount--;

            Console.WriteLine("Student deleted successfully!");
        }

        private static void UpdateStudent()
        {
            ViewAllStudents();

            if (studentCount == 0) return;

            Console.Write("\nEnter the index to update: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= studentCount) {
                Console.WriteLine("Invalid index.");
                return;
            }

            Console.WriteLine("Leave blank if you don't want to update a field.");

            Console.Write($"Current name: {studentNames[index]}. New name: ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) studentNames[index] = name;

            Console.Write($"Current ID: {studentIds[index]}. New ID: ");
            var id = Console.ReadLine();
            if (!string.IsNullOrEmpty(id)) studentIds[index] = id;

            Console.Write($"Current mobile: {studentMobileNumbers[index]}. New mobile: ");
            var mobile = Console.ReadLine();
            if (!string.IsNullOrEmpty(mobile)) studentMobileNumbers[index] = mobile;

            Console.Write($"Current email: {studentEmails[index]}. New mobile: ");
            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) studentEmails[index] = email;

            Console.WriteLine("Student updated successfully!");
        }

        private static void ViewAllStudents()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\nAll Students:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Index | Name | ID | Mobile Number | Email");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"{i} | {studentNames[i]} | {studentIds[i]} | {studentMobileNumbers[i]} | {studentEmails[i]}");
            }
        }

        private static void AddStudent()
        {
            if (studentCount >= studentNames.Length)
            {
                Console.WriteLine("Cannot add more students. Storage is FULL!");
                return;
            }

            Console.Write("Enter student name: "); var name = Console.ReadLine();
            Console.Write("Enter student ID: "); var id = Console.ReadLine();
            Console.Write("Enter student mobile: "); var mobile = Console.ReadLine();
            Console.Write("Enter student email: "); var email = Console.ReadLine();

            studentNames[studentCount] = name;
            studentIds[studentCount] = id;
            studentMobileNumbers[studentCount] = mobile;
            studentEmails[studentCount] = email;
            studentCount++;

            Console.WriteLine("Student added successfully!");
        }
    }
}
