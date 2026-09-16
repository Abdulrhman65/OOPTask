using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Course
    {
       public int CourseId { get; set; }
       public string? Title { get; set; }
       public Instructor? Instructor { get; set; }

       public string PrintDetails() 
       {
            return $"CourseId: {CourseId}, Title: {Title}, Instructor: {Instructor?.Name ?? "No Instructor"}";
       }
    }
}
