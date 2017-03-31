using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Material
    {
       
        public Material(string university, Courses course, string title, List<string> topic, List<string> tags, string category, bool printed, string path)
        {
            Universrty = university;
            Course = course;
            Title = title;
            Topic = topic;
            Tags = tags;
            Category = category;
            IsPrinted = printed;
            File = path;
            score = 0;
        }

        public int ID { get; set; }
        public string Universrty { get; set; }
        public Courses Course { get; set; }
        public string Uploader { get; set; }
        public string Title { get; set; }
        public List<string> Topic { get; set; }
        public List<string> Tags { get; set; }
        public string Category { get; set; }
        public bool IsPrinted { get; set; }
        public DateTime UploadedDateTime { get; set; }
        //file = file path
        public string File { get; set; }
        public int score;
        bool isRand = true;

        public string CourseName
        {
            get
            {
                return Course.CourseName;
            }
        }

        public int Score
        {
            get
            {
                if (isRand)
                {
                    Random rand = new Random();
                    score = rand.Next(15, 150);
                }
                isRand = true;
                return score;
               
            }
            set
            {
                score = value;
                isRand = true;
            }
        }

        public override int GetHashCode()
        {
            return (Universrty + Course.CourseName + Course.CourseNo + Uploader + Title).GetHashCode(); ;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Material);
        }
        public bool Equals(Material obj)
        {
            return obj != null && (obj.Universrty + obj.Course.CourseName + obj.Course.CourseNo + obj.Uploader + obj.Title) == (Universrty + Course.CourseName + Course.CourseNo + Uploader + Title);
        }

    }
}
