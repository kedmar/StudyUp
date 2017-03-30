using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Courses
    {
        private string text1;
        private string text2;

        public Courses(string university, string courseNo, string courseName)
        {
            this.CourseNo = courseNo;
            this.CourseName = courseName;
            University = university;
        }

        public string CourseNo { get; set; }
        public string CourseName { get; set; }
        public string University { get; set; }
    }
}
