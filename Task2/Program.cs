
namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new();
            bool Loop = true;
            int Choise;
            while (Loop)
            {
                DisplayMenu();
                Console.Write("\nEnter your choice: ");
                if(int.TryParse(Console.ReadLine(), out int choice))
                {
                    Choise = choice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                 
                
                switch (Choise)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddInstructor();
                        break;
                    case 3:
                        AddCourse();
                        break;
                    case 4:
                        EnrollStudentInCourse();
                        break;
                    case 5:
                        ShowAllStudents();
                        break;
                    case 6:
                        ShowAllCourses();
                        break;
                    case 7:
                        ShowAllInstructors();
                        break;
                    case 8:
                        FindStudent();
                        break;
                    case 9:
                        FindCourse();
                        break;
                    case 10:
                        CheckEnrollment();
                        break;
                    case 11:
                        GetInstructorNameByCourse();
                        break;
                    case 12:
                        UpdateStudentInformation();
                        break;
                    case 13:
                        DeleteStudent();
                        break;
                    case 14:
                        ExitProgram();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            


            static void DisplayMenu()
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show all Students");
                Console.WriteLine("6. Show all Courses");
                Console.WriteLine("7. Show all Instructors");
                Console.WriteLine("8. Find Student");
                Console.WriteLine("9. Find Course");
                Console.WriteLine("10. Check if Student is Enrolled in Specific Course");
                Console.WriteLine("11. Get Instructor Name by Course");
                Console.WriteLine("12. Update Student Information");
                Console.WriteLine("13. Delete Student");
                Console.WriteLine("14. Exit");
                Console.WriteLine("==================================");
            }

            void AddStudent()
            {
                Student student = new();
                Console.Write("Student ID: ");
                if(int.TryParse(Console.ReadLine(), out int Id))
                {
                    student.StudentId = Id;
                }
                else
                {
                    Console.WriteLine("Invalid input for Student ID. Please enter a valid integer.");
                    return;
                }
                Console.Write("Student Name: ");
                student.Name = Console.ReadLine();
                Console.Write("Student Age: ");
                if(int.TryParse(Console.ReadLine(), out int age))
                {
                    student.Age = age;
                }
                else
                {
                    Console.WriteLine("Invalid input for Student Age. Please enter a valid integer.");
                    return;
                }
                if(studentManager.AddStudent(student))
                {
                    Console.WriteLine("Student added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add student, Please check the details and try again.");
                }
            }

            void AddInstructor()
            {
                Instructor instructor = new();
                Console.Write("Instructor ID: ");
                if(int.TryParse(Console.ReadLine(), out int instructorId))
                {
                    instructor.InstructorId = instructorId;
                }
                else
                {
                    Console.WriteLine("Invalid input for Instructor ID. Please enter a valid integer.");
                    return;
                }
                Console.Write("Instructor Name: ");
                instructor.Name = Console.ReadLine();
                Console.Write("Instructor Specialization: ");
                instructor.Specialization = Console.ReadLine();

                if(studentManager.AddInstructor(instructor))
                {
                    Console.WriteLine("Instructor added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add instructor. Please check the details and try again.");
                }
            }

            void AddCourse()
            {
                Course course = new();
                Console.Write("Course ID: ");
                if(int.TryParse(Console.ReadLine(), out int courseId))
                {
                    course.CourseId = courseId;
                }
                else
                {
                    Console.WriteLine("Invalid input for Course ID. Please enter a valid integer.");
                    return;
                }
                Console.Write("Course Title: ");
                course.Title = Console.ReadLine();
                Console.Write("Instructor ID: ");
                int InstructorId;
                if (int.TryParse(Console.ReadLine(), out int Id))
                {
                    InstructorId = Id;
                }
                else
                {
                    Console.WriteLine("Invalid input for Instructor ID. Please enter a valid integer.");
                    return;
                }

                if (studentManager.FindInstructor(InstructorId) != null)
                {
                    course.Instructor = studentManager.FindInstructor(InstructorId);
                    if(studentManager.AddCourse(course))
                    {
                        Console.WriteLine("Course added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add course. Please check the details and try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Instructor not found.");
                }
            }

            void EnrollStudentInCourse()
            {
                Console.Write("Student ID: ");
                int studentId;
                if (int.TryParse(Console.ReadLine(), out int SId))
                {
                    studentId = SId;
                }
                else
                {
                    Console.WriteLine("Invalid input for Student ID. Please enter a valid integer.");
                    return;
                }

                Console.Write("Course ID: ");
                int courseId;
                if (int.TryParse(Console.ReadLine(), out int CId))
                {
                    courseId = CId;
                }
                else
                {
                    Console.WriteLine("Invalid input for Course ID. Please enter a valid integer.");
                    return;
                }

                if (studentManager.EnrollStudentInCourse(studentId, courseId))
                {
                    Console.WriteLine("Student enrolled in course successfully.");
                }
                else
                {
                    Console.WriteLine("Enrollment failed. Please check the student and course IDs.");
                }
            }

            void ShowAllStudents()
            {
                if (studentManager.Students.Count == 0)
                {
                    Console.WriteLine("No students found.");
                }
                else
                {
                    foreach (var student in studentManager.Students)
                    {
                        Console.WriteLine(student.PrintDetails());
                    }
                }
            }

            void ShowAllCourses()
            {
                if (studentManager.Courses.Count == 0)
                {
                    Console.WriteLine("No courses found.");
                }
                else
                {
                    foreach (var course in studentManager.Courses)
                    {
                        Console.WriteLine(course.PrintDetails());
                    }
                }
            }

            void ShowAllInstructors()
            {
                if (studentManager.Instructors.Count == 0)
                {
                    Console.WriteLine("No instructors found.");
                }
                else
                {
                    foreach (var instructor in studentManager.Instructors)
                    {
                        Console.WriteLine(instructor.PrintDetails());
                    }
                }
            }

            void FindStudent()
            {
                Console.Write("1. Find by ID\n2. Find by Name\nEnter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    choice = userChoice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }

                string searchValue = string.Empty;
                bool byName = false;
                if (choice == 1)
                {
                    Console.Write("Enter Student ID: ");
                    searchValue = Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Student Name: ");
                    searchValue = Console.ReadLine();
                    byName = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                var student = studentManager.FindStudent(searchValue, byName);
                if (student != null)
                {
                    Console.WriteLine(student.PrintDetails());
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }

            void FindCourse()
            {
                Console.Write("1. Find by ID\n2. Find by Title\nEnter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    choice = userChoice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }

                string searchValue = string.Empty;
                bool byTitle = false;
                if (choice == 1)
                {
                    Console.Write("Enter Course ID: ");
                    searchValue = Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Course Title: ");
                    searchValue = Console.ReadLine();
                    byTitle = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                var course = studentManager.FindCourse(searchValue, byTitle);
                if (course != null)
                {
                    Console.WriteLine(course.PrintDetails());
                }
                else
                {
                    Console.WriteLine("Course not found.");
                }
            }

            void CheckEnrollment()
            {
                Console.Write("1. Find by Student ID and Course ID\n2. Find by Student Name and Course Title\nEnter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    choice = userChoice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }

                string searchStudentValue = string.Empty;
                string searchCourseValue = string.Empty;
                bool byName = false;
                if (choice == 1)
                {
                    Console.Write("Enter Student ID: ");
                    searchStudentValue = Console.ReadLine();
                    Console.Write("Enter Course ID: ");
                    searchCourseValue = Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Student Name: ");
                    searchStudentValue = Console.ReadLine();
                    Console.Write("Enter Course Title: ");
                    searchCourseValue = Console.ReadLine();
                    byName = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                if (studentManager.IsStudentEnrolledInCourse(searchStudentValue, searchCourseValue, byName))
                {
                    Console.WriteLine("The student is enrolled in the course.");
                }
                else
                {
                    Console.WriteLine("The student is not enrolled in the course.");
                }
            }

            void GetInstructorNameByCourse()
            {
                Console.Write("1. Find by ID\n2. Find by Title\nEnter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    choice = userChoice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }

                string searchCourseValue = string.Empty;
                bool byTitle = false;

                if (choice == 1)
                {
                    Console.Write("Enter Course ID: ");
                    searchCourseValue = Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Course Title: ");
                    searchCourseValue = Console.ReadLine();
                    byTitle = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }
                Console.WriteLine(studentManager.InstructorByCourse(searchCourseValue, byTitle));

            }

            void UpdateStudentInformation()
            {
                Console.WriteLine("\n1. Find Student by ID\n2. Find Student by Name");
                Console.Write("Enter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    choice = userChoice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }

                string SearchValue = string.Empty;
                bool byName = false;
                if (choice == 1)
                {
                    Console.Write("Enter Student ID: ");
                    SearchValue = Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Student Name: ");
                    SearchValue = Console.ReadLine();
                    byName = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();
                Console.Write("Enter new age: ");
                int newAge;
                if (int.TryParse(Console.ReadLine(), out int userNewAge))
                {
                    newAge = userNewAge;
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a valid number.");
                    return;
                }

                if (studentManager.UpdateStudent(SearchValue, newName, newAge, byName))
                {
                    Console.WriteLine("Student information updated successfully.");
                }
            }

            void DeleteStudent()
            {
                Console.WriteLine("\n1. Find Student by ID\n2. Find Student by Name");
                Console.Write("Enter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    choice = userChoice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }

                string SearchValue = string.Empty;
                bool byName = false;
                if (choice == 1)
                {
                    Console.Write("Enter Student ID: ");
                    SearchValue = Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Student Name: ");
                    SearchValue = Console.ReadLine();
                    byName = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                if (studentManager.DeleteStudent(SearchValue, byName))
                {
                    Console.WriteLine("Student deleted successfully.");
                }
            }

            void ExitProgram()
            {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    Loop = false;
            }
        }
    }
}
