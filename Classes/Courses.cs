using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Courses
    {
        public string CourseNo { get; set; }
        public string CourseName { get; set; }
        public string University { get; set; }

        public Courses(string university, string courseNo, string courseName)
        {
            this.CourseNo = courseNo;
            this.CourseName = courseName;
            University = university;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Courses);
        }
        public bool Equals(Courses obj)
        {
            return obj != null && obj.CourseNo == CourseNo && obj.CourseName == CourseName && obj.University == University;
        }

        public static bool operator ==(Courses a, Courses b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(Courses a, Courses b)
        {
            return !(a == b);
        }

    }
}
