using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace StudyUpController
{
    public class FakeController : IController
    {
        public List<string> GetAllCategories()
        {
            return new List<string> { "Summary", "Lectures", "Practices", "Formulas Pages", "Tests", "Exercises", "Audio Class", "Video Class" };
        }

        public List<Courses> GetAllCourses()
        {
            return new List<Courses> {
                new Courses("Ben Gurion","3728907123","Data Mining"),
                new Courses("Ben Gurion","3725207123","Artifical Inteligince"),
                new Courses("Ben Gurion","3725202323","Web Dev")
            };
        }

        public List<string> GetAllTags()
        {
            return new List<string> {
                "#data_mining",
                "#data_preparation",
                "#search",
                "#web_deb",
        };
        }

        public List<string> GetAllTopics()
        {
            return new List<string>();
        }

        public List<string> GetAllUniversities()
        {
            return new List<string> {
                "Ben Gurion"
        };
        }

        public List<string> GetAllUploadersNames()
        {
            return new List<string>();
        }

        public Dictionary<Material, double> RetreiveMaterialsAdvancedSearch(string tag)
        {
            return new Dictionary<Material, double>
            {
                {new Material( "Ben Gurion", new Courses("Ben Gurion","3728907123","Artifical Inteligence"),"Searching algorithms",new List<string>(),new List<string>
                { "#search" },"Lectures",true,String.Empty), 3.7 },

                { new Material( "Ben Gurion", new Courses("Ben Gurion","3728907123","Data Mining"),"Data Preparation",new List<string>(),new List<string>
                { "#data_preparation" },"Tests",true,String.Empty), 2.5 },

                { new Material( "Ben Gurion", new Courses("Ben Gurion","3725202323","Web Dev"),"Data Preparation",new List<string>(),new List<string>
                {                 "#web_deb"  },"Tests",true,String.Empty), 1.6 },
            };
        }

        public Dictionary<Material, double> RetreiveMaterialsAdvancedSearch(string university, string courseNo, string courseName, string uploaderMail, string title, List<string> topic, List<string> tags, string category, bool isPrinter)
        {
            return new Dictionary<Material, double>
            {
                {new Material( "Ben Gurion", new Courses("Ben Gurion","3728907123","Artifical Inteligence"),"Searching algorithms",new List<string>(),new List<string>
                { "#search" },"Lectures",true,String.Empty), 3.7 },

                { new Material( "Ben Gurion", new Courses("Ben Gurion","3728907123","Data Mining"),"Data Preparation",new List<string>(),new List<string>
                { "#data_preparation" },"Tests",true,String.Empty), 2.5 },

                { new Material( "Ben Gurion", new Courses("Ben Gurion","3725202323","Web Dev"),"Data Preparation",new List<string>(),new List<string>
                {                 "#web_deb"  },"Tests",true,String.Empty), 1.6 },
            };
        }

        public Dictionary<Material, double> RetreiveMaterialsSimpleSearch(string query)
        {
            return new Dictionary<Material, double>
            {
                {new Material( "Ben Gurion", new Courses("Ben Gurion","3728907123","Artifical Inteligence"),"Searching algorithms",new List<string>(),new List<string>
                { "#search" },"Lectures",true,String.Empty), 3.7 },

                { new Material( "Ben Gurion", new Courses("Ben Gurion","3728907123","Data Mining"),"Data Preparation",new List<string>(),new List<string>
                { "#data_preparation" },"Tests",true,String.Empty), 2.5 },

                { new Material( "Ben Gurion", new Courses("Ben Gurion","3725202323","Web Dev"),"Data Preparation",new List<string>(),new List<string>
                {                 "#web_deb"  },"Tests",true,String.Empty), 1.6 },
            };
        }

        public bool UploadMaterial(Material newMaterial)
        {
            return true;
        }
    }
}
