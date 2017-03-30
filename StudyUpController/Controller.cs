using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using StudyUpModel;

namespace StudyUpController
{

    public class Controller : IController
    {
        private IModel m_model;
        // private IView m_view;

        /// <summary>
        /// sets the model cobject
        /// </summary>
        /// <param name="model">our model object</param>
        public void SetModel(IModel model)
        {
            m_model = model;
        }
        /*
        /// <summary>
        /// sets the view object
        /// </summary>
        /// <param name="view">our view object</param>
        public void SetView(IView view)
        {
            m_view = view;
        }
        */
        public List<string> GetAllCategories()
        {

            throw new NotImplementedException();
        }

        public List<Courses> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTags()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTopics()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllUniversities()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllUploadersMails()
        {
            throw new NotImplementedException();
        }

        public List<Material> RetreiveMaterialsAdvancedSearch(string university, string courseNo, string courseName, string uploaderMail, string title, List<string> topic, List<string> tags, CategoryEnum category, bool isPrinter, DateTime uploadDateTime)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Material, double> RetreiveMaterialsSimpleSearch(string query)
        {
            int i, j, count;
            Material m;
            string lowerQuery = query.ToLower();
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] words = lowerQuery.Split(delimiterChars);
            List<Material> mList = m_model.RetreiveMaterialsSimpleSearch(words);
            for (i = 0; i < mList.Count(); i++)
            {
                m = mList[i];
                count = 0;
                for (j = 0; j < words.Count(); j++)
                {
                    if (m.Course.CourseName == words[j]) count++;
                    if (m.)
                }
            }

            throw new NotImplementedException();
        }

        public bool UploadMaterial(Material newMaterial)
        {
            throw new NotImplementedException();
        }
    }
}
