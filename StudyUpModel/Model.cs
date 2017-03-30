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

        public Model()
        {
            dbPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\StudyUpModel\\StudyUpDB.accdb";
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
                field.CourseName = ds.Tables[0].Rows[i][1].ToString();
                //add uni name here
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

        private List<string> GetTopicsFromDatabase()
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

        private List<string> GetMailsFromDatabase()
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

        private List<string> GetUniversitiesFromDatabase()
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
            throw new NotImplementedException();
        }

        #endregion

        #region preload
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

        public List<string> GetAllUploadersMails()
        {
            mails = GetMailsFromDatabase();
            return mails;
        }

        #endregion

    }
}
