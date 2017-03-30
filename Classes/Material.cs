using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Material
    {
       
        public Material(string university, Courses course, string title, List<string> topic, List<string> tags, string category, bool printed, DateTime uploaded, string path)
        {
            Universrty = university;
            Course = course;
            Title = title;
            Topic = topic;
            Tags = tags;
            SetCategory(category);
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
        public CategoryEnum Category { get; set; }

        private void SetCategory(string cat)
        {
            if (cat == "AudioClass")
                Category = CategoryEnum.AudioClass;
            if (cat == "FormulasPage")
                Category = CategoryEnum.FormulasPage;
            if (cat == "Lecture")
                Category = CategoryEnum.Lecture;
            if (cat == "Practice")
                Category = CategoryEnum.Practice;
            if (cat == "Summary")
                Category = CategoryEnum.Summary;
            if (cat == "Tests")
                Category = CategoryEnum.Tests;
            else
                Category = CategoryEnum.VideoClass;
        }
        public bool IsPrinted { get; set; }
        public DateTime UploadedDateTime { get; set; }
        //file = file path
        public string File { get; set; }
        public int score { get; set; }


    }
}
