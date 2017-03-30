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
        public int score { get; set; }


    }
}
