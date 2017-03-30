using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Collections.ObjectModel;

namespace StudyUpModel
{
    public interface IModel
    {
        Boolean dbConnect();
        void dbClose();
        List<Material> RetreiveMaterialsSimpleSearch(string[] queryWords);
        List<Material> RetreiveMaterialsAdvancedSearch(string university, Courses course, string uploaderMail, string title, List<string> topic, List<string>
            tags, string category, bool isPrinter);
        bool UploadMaterial(Material newMaterial);
        List<string> GetAllUniversities();
        List<Courses> GetAllCourses();
        List<string> GetAllUploadersNames();
        List<string> GetAllTopics();
        List<string> GetAllTags();
        List<string> GetAllCategories();

    }
}
