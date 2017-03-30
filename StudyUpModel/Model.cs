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
                Courses field = new Courses();
                field.CourseNo = ds.Tables[0].Rows[i][0].ToString(); ;
                field.CourseName = ds.Tables[0].Rows[i][2].ToString();
                field.University = UniNames[Convert.ToInt32(ds.Tables[0].Rows[i][1])];
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

        public List<Material> RetreiveMaterialsAdvancedSearch(string university, string courseNo, string courseName, string uploaderMail, string title, List<string> topic, List<string> tags, CategoryEnum category, bool isPrinter, DateTime uploadDateTime)
        {
            throw new NotImplementedException();
        }

        public List<Material> RetreiveMaterialsSimpleSearch(string[] queryWords)
        {
            throw new NotImplementedException();
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
                "INSERT INTO Documents ([ID], [Path], [Type], [HandWrite], [Score], [Title], [UploadDate], [TopicID]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)", connection);

            command.Parameters.AddWithValue("@Path", data[0]);
            command.Parameters.AddWithValue("@ID", data[2]);
            command.Parameters.AddWithValue("@Type", data[1]);
            command.Parameters.AddWithValue("@HandWrite", data[3]);
            command.Parameters.AddWithValue("@Score", data[0]);
            command.Parameters.AddWithValue("@Title", data[2]);
            command.Parameters.AddWithValue("@UploadDate", data[1]);
            command.Parameters.AddWithValue("@TopicID", data[3]);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }

        private bool InsertFileUploader(Material newMaterial)
        {
            throw new NotImplementedException();
        }

        private bool InsertFileClass(Material newMaterial)
        {
            throw new NotImplementedException();
        }

        private bool InsertFileTags(Material newMaterial)
        {
            throw new NotImplementedException();
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
