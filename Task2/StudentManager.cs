using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/*
من فضلك يا بشمهندس لا تنس قراءة ملف Readme.md
*/

namespace Task2
{
    public class StudentManager
    {
        public List<Student> Students { get; set; } = new();
        public List<Course> Courses { get; set; } = new();
        public List<Instructor> Instructors { get; set; } = new();

        public bool AddStudent(Student student)
        {
            if (Students.Any(s => s.StudentId == student.StudentId))
            {
                Console.WriteLine("Student already exists.");
                return false;
            }
            else
            {
                Students.Add(student);
                return true;
            }
        }

        public bool AddCourse(Course course)
        {
            if (Courses.Any(c => c.CourseId == course.CourseId))
            {
                Console.WriteLine("Course already exists.");
                return false;
            }
            else
            {
                Courses.Add(course);
                return true;
            }
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (Instructors.Any(i => i.InstructorId == instructor.InstructorId))
            {
                Console.WriteLine("Instructor already exists.");
                return false;
            }
            else
            {
                Instructors.Add(instructor);
                return true;
            }
        }

        public Student FindStudent(string searchValue, bool byName)
        {
            if (byName)
            {
                return Students.Find(s => s.Name == searchValue);
            }
            else
            {
                return Students.Find(s => s.StudentId == int.Parse(searchValue));
            }
        }

        public Course FindCourse(string searchValue, bool byTitle)
        {
            if (byTitle)
            {
                return Courses.Find(c => c.Title == searchValue);
            }
            else
            {
                return Courses.Find(c => c.CourseId == int.Parse(searchValue));
            }
        }

        public Instructor FindInstructor(int instructorId)
        {
            return Instructors.Find(i => i.InstructorId == instructorId);
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            var foundStudent = FindStudent(studentId.ToString(), false);
            var foundCourse = FindCourse(courseId.ToString(), false);
            if (foundStudent == null)
            {
                Console.WriteLine("Student not found.");
                return false;
            }
            if (foundCourse == null)
            {
                Console.WriteLine("Course not found.");
                return false;
            }
            return foundStudent.Enroll(foundCourse);
        }

        public bool UpdateStudent(string StudentSearchValue, string newName, int newAge, bool byName)
        {
            var foundStudent = FindStudent(StudentSearchValue, byName);
            if (foundStudent == null)
            {
                Console.WriteLine("Student not found.");
                return false;
            }
            foundStudent.Name = newName;
            foundStudent.Age = newAge;
            return true;
        }

        public bool DeleteStudent(string StudentSearchValue, bool byName)
        {
            var foundStudent = FindStudent(StudentSearchValue, byName);
            if (foundStudent == null)
            {
                Console.WriteLine("Student not found.");
                return false;
            }
            Students.Remove(foundStudent);
            return true;
        }

        // Bonus 1
        public bool IsStudentEnrolledInCourse(string StudentSearchValue, string CourseSearchValue, bool byName)
        {
            
                var foundStudent = FindStudent(StudentSearchValue, byName);
                if (foundStudent == null)
                {
                    Console.WriteLine("Student not found.");
                    return false;
                }
                var foundCourse = FindCourse(CourseSearchValue, byName);
                if (foundCourse == null)
                {
                    Console.WriteLine("Course not found.");
                    return false;
                }
                return foundStudent.Courses.Contains(foundCourse);        
        }

        // Bonus 2
        public string InstructorByCourse(string courseSearchValue, bool byTitle)
        {
            var foundCourse = FindCourse(courseSearchValue, byTitle);
            if (foundCourse == null)
            {
                return "Course not found.";
            }
            if (foundCourse.Instructor == null)
            {
                return "No instructor assigned to this course.";
            }
            return $"Instructor Name: {foundCourse.Instructor.Name}";
        }
    }
}
