using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Models
{
    public class CourseInfo
    {
        public List<CourseCategory> CourseCategoryList { get; set; }
        public List<Course> CourseList { get; set; }

        public CourseInfo()
        {
            this.CourseCategoryList = new List<CourseCategory>();
            this.CourseList = new List<Course>();
        }
    }
}