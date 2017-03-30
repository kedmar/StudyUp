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

            return m_model.GetAllCategories();
        }

        public List<Courses> GetAllCourses()
        {
            return m_model.GetAllCourses();
        }

        public List<string> GetAllTags()
        {
            return m_model.GetAllTags();
        }

        public List<string> GetAllTopics()
        {
            return m_model.GetAllTopics();
        }

        public List<string> GetAllUniversities()
        {
            return m_model.GetAllUniversities();
        }

        public List<string> GetAllUploadersNames()
        {
            return m_model.GetAllUploadersNames();
        }



        public Dictionary<Material, double> RetreiveMaterialsAdvancedSearch(string university, string courseNo, string courseName, string uploaderMail, string title, List<string> topic, List<string> tags, string category, bool isPrinter)
        {

            int i, j, l, count;
            Material m;
            Courses course = new Courses(university, courseNo, courseName);
            Dictionary<Material, double> ret = new Dictionary<Material, double>();
            List<Material> mList = m_model.RetreiveMaterialsAdvancedSearch(university, course, uploaderMail,
                title, topic, tags, category, isPrinter);
            for (i = 0; i < mList.Count(); i++)
            {
                count = 0;
                m = mList[i];
                if (m.Universrty == university) count++;
                if (m.Course == course) count++;
                if (m.UploaderMail == uploaderMail) count++;
                if (m.Title == title) count++;
                if (m.Topic == topic) count++;
                for (j = 0; j < m.Tags.Count(); j++)
                {
                    if (m.Tags[j] == )
                }
                
            }


            return; 
        }


        public Dictionary<Material, double> RetreiveMaterialsAdvancedSearch(string tag)
        {
            List<string> tagList = new List<string>();
            tagList.Add(tag);
            return RetreiveMaterialsAdvancedSearch(null, null, null, null, null, null, tagList, null, false);
        }

        public Dictionary<Material, double> RetreiveMaterialsSimpleSearch(string query)
        {
            int i, j, l, count;
            Material m;
            Dictionary<Material, double> ret = new Dictionary<Material, double>();
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
                    for (l = 0; l < m.Tags.Count(); l++)
                        if (m.Tags[l].Equals(words[j])) count++;
                    for (l = 0; l < m.Topic.Count(); l++)
                        if (m.Topic[l].Equals(words[j])) count++;
                    if (m.Topic.Equals(words[j])) count++;
                    if (m.Universrty.Equals(words[j])) count++;
                }
                if (count > 0) ret.Add(m, count);
            }

            return ret;
        }

        public string GetUserMail()
        {
            throw new NotImplementedException();
        }

        public bool UploadMaterial(Material newMaterial)
        {
            return m_model.UploadMaterial(newMaterial);
        }
    }
}
