using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task2
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses  { get; set; } = new();

        public bool Enroll(Course course) 
        {
            if (Courses.Contains(course))
            {
                Console.WriteLine("Student is already enrolled in this course.");
                return false;
            }
            else
            {
                 Courses.Add(course);
                 return true;
            }
            
        }
        public string PrintDetails()
        {
            return $"StudentId: {StudentId}, Name: {Name}, Age: {Age}, Courses: {string.Join(", ", Courses.Select(c => c.Title))}";
        }
    }
}
