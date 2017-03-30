using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Material
    {
        public string Universrty { get; set; }
        public Courses Course { get; set; }
        public string UploaderMail { get; set; }
        public string Title { get; set; }
        public List<string> Topic { get; set; }
        public List<string> Tags { get; set; }
        public CategoryEnum Catgory { get; set; }
        public bool IsPrinted { get; set; }
        public DateTime UpldoadeDateTime { get; set; }

        public string File { get; set; }

    }
}
