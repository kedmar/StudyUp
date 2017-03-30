using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Collections.ObjectModel;

namespace StudyUpController
{
    public interface IController
    {
        /*
         * 1. Split to words
         * 2. Pass to model and retrieve results
         * 3. 
         */
        Dictionary<Material, double> RetreiveMaterialsSimpleSearch(string query);
        Dictionary<Material, double> RetreiveMaterialsAdvancedSearch(string university, string courseNo,
           string courseName, string uploaderMail, string title, List<string> topic, List<string>
            tags, string category, bool isPrinter, DateTime uploadDateTime);
        bool UploadMaterial(Material newMaterial);
        List<string> GetAllUniversities();
        List<Courses> GetAllCourses();
        List<string> GetAllUploadersNames();
        List<string> GetAllTopics();
        List<string> GetAllTags();
        List<string> GetAllCategories();
        List<Material> RetreiveMaterialsAdvancedSearch(string tag);
    }
}
