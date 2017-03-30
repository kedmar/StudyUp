using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Material
    {
        /*public Courses(string university, string courseNo, string courseName)
        {
            this.CourseNo = courseNo;
            this.CourseName = courseName;
            University = university;
        }*/
        public Material(string university, Courses course, string uploaderMail, string title, List<string> topic, List<string> tags, CategoryEnum category, bool printed, DateTime uploaded, string path)
        {
            Universrty = university;
            Course = course;
            UploaderMail = uploaderMail;
            Title = title;
            Topic = topic;
            Tags = tags;
            Category = category;
            IsPrinted = printed;
            UploadedDateTime = uploaded;
            File = path;

        }

        public int ID { get; set; }
        public string Universrty { get; set; }
        public Courses Course { get; set; }
        public string UploaderMail { get; set; }
        public string Title { get; set; }
        public List<string> Topic { get; set; }
        public List<string> Tags { get; set; }
        private CategoryEnum Category { get; set; }
        public string CategoryString
        {
            get
            {
                return getCategoryEnum();
            }

            set
            {
                if (value == "AudioClass")
                    Category = CategoryEnum.AudioClass;
                if (value == "FormulasPage")
                    Category = CategoryEnum.FormulasPage;
                if (value == "Lecture")
                    Category = CategoryEnum.Lecture;
                if (value == "Practice")
                    Category = CategoryEnum.Practice;
                if (value == "Summary")
                    Category = CategoryEnum.Summary;
                if (value == "Tests")
                    Category = CategoryEnum.Tests;
                else
                    Category = CategoryEnum.VideoClass;
            }
        }
        public bool IsPrinted { get; set; }
        public DateTime UploadedDateTime { get; set; }
        //file = file path
        public string File { get; set; }
        public int score { get; set; }

        private string getCategoryEnum()
        {
            if (Category == CategoryEnum.AudioClass)
                return "AudioClass";
            if (Category == CategoryEnum.FormulasPage)
                return "FormulasPage";
            if (Category == CategoryEnum.Lecture)
                return "Lecture";
            if (Category == CategoryEnum.Practice)
                return "Practice";
            if (Category == CategoryEnum.Summary)
                return "Summary";
            if (Category == CategoryEnum.Tests)
                return "Tests";
            else
                return "VideoClass";
        }


    }
}
