using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Collections.ObjectModel;

namespace StudyUpModel
{
    public class Model : IModel
    {
        private OleDbConnection connection;
        private List<string> catagories;
        private List<Courses> courses;
        private List<string> tags;
        private List<string> topics;
        private List<string> universities;
        private List<string> mails;
        private string dbPath;
        private string dataPath;
        private string counterPath;
        private int fileCount;
        private string currentUser;

        public Model()
        {
            currentUser = "Legacy";
            dbPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\StudyUpModel\\StudyUpDB.accdb";
            dataPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\StudyUpModel\\Data";
            counterPath = dataPath + "\\FileCount";
            currentUser = "legacy";

            GetFileCount();
        }

        private bool FileCountUp()
        {
            try
            {
                if (!File.Exists(counterPath))
                    File.Create(counterPath);
            }
            catch (Exception e)
            {
                return false;
            }

            try
            {
                using (StreamWriter newTask = new StreamWriter(counterPath, false))
                    newTask.Write(fileCount.ToString());
                return true;
            }
            catch (Exception e)
            {
                if (File.Exists(counterPath))
                    File.Delete(counterPath);
                return false;
            }
        }

        #region db

        /// <summary>
        /// Connects to the access DB; Requires the "Microsoft Access Database Engine 2010 Redistributable"
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        public Boolean dbConnect()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath + "; Persist Security Info=False;";
            try
            {
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// disconnects from the access db
        /// </summary>
        public void dbClose()
        {
            connection.Close();
        }

        private List<string> GetCategoriesFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Types", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            List<string> record_list = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string field = ds.Tables[0].Rows[i][0].ToString();
                if (!record_list.Contains(field))
                    record_list.Add(field);
            }
            dbClose();
            return record_list;
        }

        private List<Courses> GetCoursesFromDatabase()
        {
            Dictionary<int, string> UniNames = GetUniversityNamesFromDatabase();

            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Classes", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            List<Courses> record_list = new List<Courses>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string CourseNo = ds.Tables[0].Rows[i][0].ToString(); ;
                string CourseName = ds.Tables[0].Rows[i][2].ToString();
                string University = UniNames[Convert.ToInt32(ds.Tables[0].Rows[i][1])];
                Courses field = new Courses(University, CourseNo, CourseName);
                if (!record_list.Contains(field))
                    record_list.Add(field);
            }
            dbClose();
            return record_list;
        }

        private List<string> GetTagsFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Tags", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            List<string> record_list = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string field = ds.Tables[0].Rows[i][0].ToString();
                if (!record_list.Contains(field))
                    record_list.Add(field);
            }
            dbClose();
            return record_list;
        }

        private List<string> GetTopicsFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT Topic FROM Topics", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            List<string> record_list = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string field = ds.Tables[0].Rows[i][0].ToString();
                if (!record_list.Contains(field))
                    record_list.Add(field);
            }
            dbClose();
            return record_list;
        }

        private List<string> GetUsersFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT User FROM Users", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            List<string> record_list = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string field = ds.Tables[0].Rows[i][0].ToString();
                if (!record_list.Contains(field))
                    record_list.Add(field);
            }
            dbClose();
            return record_list;
        }

        private List<string> GetUniversitiesFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT University FROM Universities", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            List<string> record_list = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string field = ds.Tables[0].Rows[i][0].ToString();
                if (!record_list.Contains(field))
                    record_list.Add(field);
            }
            dbClose();
            return record_list;
        }



        private Dictionary<int, string> GetUniversityNamesFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Universities", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            Dictionary<int, string> record_list = new Dictionary<int, string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                string name = ds.Tables[0].Rows[i][1].ToString();
                if (!record_list.ContainsKey(id))
                    record_list.Add(id, name);
            }
            dbClose();
            return record_list;
        }
        private Dictionary<string, int> GetTopicNamesFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Topics", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            Dictionary<string, int> record_list = new Dictionary<string, int>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                string name = ds.Tables[0].Rows[i][1].ToString();
                if (!record_list.ContainsKey(name))
                    record_list.Add(name, id);
            }
            dbClose();
            return record_list;
        }

        public List<Material> RetreiveMaterialsAdvancedSearch(string university, string courseNo, string courseName, string uploaderMail, string title, List<string> topic, List<string> tags, CategoryEnum category, bool isPrinter, DateTime uploadDateTime)
        {
            List<Material> results = new List<Material>();



            return results;
        }

        public List<Material> RetreiveMaterialsSimpleSearch(string[] queryWords)
        {
            List<Material> results = new List<Material>();
            List<int> IDs = new List<int>();

            for(int i = 0; i < queryWords.Length; i++)
            {
                SimpleSearch(results, IDs, queryWords[i]);
            }

            return results;
        }

        private void SimpleSearch(List<Material> results, List<int> IDs, string query)
        {
            DataSet ds = new DataSet();
            int queryNum;
            bool isNum = int.TryParse(query, out queryNum);
            try
            {
                if (!dbConnect())
                    return;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command;

                string cmdStr = "SELECT * FROM Documents WHERE [Path] = '" + query + "' OR [Type] = '" + query + "' OR [Title] = '" + query + "'";
                if (isNum)
                    cmdStr = " OR [ID] = '" + queryNum + "'";

                //Create the InsertCommand.
                command = new OleDbCommand(cmdStr, connection);

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dbClose();
            }
            catch(Exception e)
            {
                return;
            }
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int currentID = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                if (!IDs.Contains(currentID))
                {
                    string university = GetDocUniversity(currentID);
                    Courses course = GetDocCourse(currentID, university);
                    string title = ds.Tables[0].Rows[i][5].ToString();
                    List<string> topic = GetDocTopics(currentID);
                    List<string> tags = GetDocTags(currentID);
                    string category = ds.Tables[0].Rows[i][2].ToString();
                    bool printed = Convert.ToBoolean(ds.Tables[0].Rows[i][3]);
                    string path = ds.Tables[0].Rows[i][1].ToString();
                    Material mat = new Material(university, course, title, topic, tags, category, printed, path);
                    mat.ID = currentID;
                    mat.Uploader = currentUser;
                    mat.UploadedDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                    results.Add(mat);
                    IDs.Add(currentID);

                }
            }
        }

        private Courses GetDocCourse(int docID, string university)
        {
            int classID = GetClassID(docID);
            string className = "";
            if (classID != 0)
            {
                Dictionary<int, string> classes = getClassNames(classID);
                if (classes.ContainsKey(classID))
                    className = classes[classID];
            }
            Courses course = new Courses(university, classID.ToString(), className);
            return course;
        }

        private Dictionary<int, string> getClassNames(int classID)
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Classes", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            Dictionary<int, string> record_list = new Dictionary<int, string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int key = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                string field = ds.Tables[0].Rows[i][2].ToString();
                if (!record_list.ContainsKey(key))
                    record_list.Add(key, field);
            }
            dbClose();
            return record_list;
        }

        private int GetClassID(int docID)
        {
            if (!dbConnect())
                return 0;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT ClassID FROM Class-Doc WHERE [DocID] = '" + docID + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            int classID = 0;
            if (ds.Tables[0].Rows.Count > 0)
                classID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            dbClose();
            return classID;
        }

        private string GetDocUniversity(int docID)
        {
            int uniID = GetUniversityID(docID);
            if (uniID == 0)
                return "";
            Dictionary<int, string> unis = getUniversityNames();
            string uniName = "";
            if (unis.ContainsKey(uniID))
                uniName = unis[uniID];
            return uniName;
        }

        private Dictionary<int, string> getUniversityNames()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Universities", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            Dictionary<int, string> record_list = new Dictionary<int, string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int key = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                string field = ds.Tables[0].Rows[i][1].ToString();
                if (!record_list.ContainsKey(key))
                    record_list.Add(key, field);
            }
            dbClose();
            return record_list;
        }

        private int GetUniversityID(int docID)
        {
            if (!dbConnect())
                return 0;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT UniversityID FROM Class-Doc WHERE [DocID] = '" + docID + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            int uniID = 0;
            if (ds.Tables[0].Rows.Count > 0)
                uniID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            dbClose();
            return uniID;
        }

        private List<string> GetDocTags(int docID)
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Documents WHERE [ID] = '" + docID + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            List<string> record_list = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string field = ds.Tables[0].Rows[i][0].ToString();
                if (!record_list.Contains(field))
                    record_list.Add(field);
            }
            dbClose();
            return record_list;
        }

        private List<string> GetDocTopics(int docID)
        {
            List<int> topicIDs = getTopicIDs(docID);
            Dictionary<int, string> topics = getTopicNames();
            List<string> topicNames = new List<string>();
            foreach (int id in topicIDs)
                if(topics.ContainsKey(id))
                    topicNames.Add(topics[id]);
            return topicNames;
        }

        private Dictionary<int, string> getTopicNames()
        {

            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Topics", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            Dictionary<int, string> record_list = new Dictionary<int, string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int key = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                string field = ds.Tables[0].Rows[i][1].ToString();
                if (!record_list.ContainsKey(key))
                    record_list.Add(key,field);
            }
            dbClose();
            return record_list;
        }

        private List<int> getTopicIDs(int docID)
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT TopicID FROM Doc-Topic WHERE [DocumentID] = '" + docID + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            List<int> record_list = new List<int>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int field = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                if (!record_list.Contains(field))
                    record_list.Add(field);
            }
            dbClose();
            return record_list;
        }

        public bool UploadMaterial(Material newMaterial)
        {
            //copy file to destination folder with set ID as name
            //if successful insert into DB
            //counter++
            try
            {
                if (!File.Exists(newMaterial.File))
                    return false;
                File.Copy(newMaterial.File, dataPath + "\\" + Convert.ToInt32(fileCount));
            }
            catch (Exception e)
            {
                return false;
            }
            newMaterial.ID = fileCount;
            if (!InsertFileToDB(newMaterial))
                return false;
            FileCountUp();
            return true;
        }

        private bool InsertFileToDB(Material newMaterial)
        {
            //insert file to documents table
            if (!InsertFile(newMaterial))
                return false;
            //insert to user-doc table
            if (!InsertFileUploader(newMaterial))
                return false;
            //insert to class-doc table
            if (!InsertFileClass(newMaterial))
                return false;
            //insert to topic-doc table
            if (!InsertFileTopics(newMaterial))
                return false;
            //insert to file-tags table
            if (!InsertFileTags(newMaterial))
                return false;
            return true;
        }

        private bool InsertFile(Material newMat)
        {
            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(
                "INSERT INTO Documents ([ID], [Path], [Type], [HandWrite], [Score], [Title], [UploadDate]) VALUES (?, ?, ?, ?, ?, ?, ?)", connection);

            command.Parameters.AddWithValue("@ID", newMat.ID);
            command.Parameters.AddWithValue("@Path", dataPath + "\\" + Convert.ToInt32(fileCount));
            command.Parameters.AddWithValue("@Type", newMat.Category);
            command.Parameters.AddWithValue("@HandWrite", newMat.IsPrinted);
            command.Parameters.AddWithValue("@Score", newMat.score);
            command.Parameters.AddWithValue("@Title", newMat.Title);
            command.Parameters.AddWithValue("@UploadDate", newMat.UploadedDateTime);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }

        private bool InsertFileUploader(Material newMat)
        {
            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(
                "INSERT INTO User-Doc ([User], [DocID]) VALUES (?, ?)", connection);

            command.Parameters.AddWithValue("@User", currentUser);
            command.Parameters.AddWithValue("@DocID", newMat.ID);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }

        private bool InsertFileClass(Material newMat)
        {
            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(
                "INSERT INTO Class-Doc ([User], [DocID], [UniversityID]) VALUES (?, ?, ?)", connection);

            command.Parameters.AddWithValue("@ClassID", newMat.Course.CourseNo);
            command.Parameters.AddWithValue("@DocID", newMat.ID);
            command.Parameters.AddWithValue("@UniversityID", newMat.Universrty);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }

        private bool InsertFileTopics(Material newMat)
        {
            Dictionary<string, int> topicNames = GetTopicNamesFromDatabase();
            foreach (string t in newMat.Topic)
            {
                InsertTopic(topicNames[t], newMat.ID);
            }
            
            return true;
        }

        private bool InsertTopic(int topic, int doc)
        {
            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(
                "INSERT INTO Doc-Topic ([DocumentID], [TopicID]) VALUES (?, ?)", connection);

            command.Parameters.AddWithValue("@DocumentID", topic);
            command.Parameters.AddWithValue("@TopicID", doc);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }

        private bool InsertFileTags(Material newMat)
        {
            List<string> tags = GetTagsFromDatabase();
            List<string> newTags = new List<string>();
            foreach (string t in newMat.Topic)
            {
                if (!tags.Contains(t))
                    newTags.Add(t);
                if (!InsertDocTag(newMat.ID, t))
                    return false;
            }
            foreach (string t in tags)
            {
                InsertTag(t);
                if (!InsertDocTag(newMat.ID, t))
                    return false;
            }

            return true;
        }

        private bool InsertTag(string t)
        {
            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(
                "INSERT INTO Tags ([Tag]) VALUES (?)", connection);

            command.Parameters.AddWithValue("@Tag", t);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }

        private bool InsertDocTag(int ID, string t)
        {
            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(
                "INSERT INTO Doc-Tag ([DocID], [Tag]) VALUES (?, ?)", connection);

            command.Parameters.AddWithValue("@DocID", ID);
            command.Parameters.AddWithValue("@Tag", t);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }

        #endregion

        #region preload

        private void GetFileCount()
        {
            try
            {
                if (File.Exists(counterPath))
                    fileCount = Convert.ToInt32(File.ReadAllText(counterPath));
                else
                    fileCount = 1;
            }
            catch (Exception e)
            {
                fileCount = 1;
            }
        }
        public List<string> GetAllCategories()
        {
            catagories = GetCategoriesFromDatabase();
            return catagories;
        }

        public List<Courses> GetAllCourses()
        {

            courses = GetCoursesFromDatabase();
            return courses;
        }

        public List<string> GetAllTags()
        {
            tags = GetTagsFromDatabase();
            return tags;
        }

        public List<string> GetAllTopics()
        {
            topics = GetTopicsFromDatabase();
            return topics;
        }

        public List<string> GetAllUniversities()
        {
            universities = GetUniversitiesFromDatabase();
            return universities;
        }

        public List<string> GetAllUploadersNames()
        {
            mails = GetUsersFromDatabase();
            return mails;
        }

        #endregion

    }
}
