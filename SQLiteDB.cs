using System.Collections.Generic;
using SQLite;
using System.IO;

namespace XA_Mid2Lab2
{
    class SQLiteDB
    {
        //database path
        private readonly string dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Mid2Lab.db3");
        // Constructor
        public SQLiteDB()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Lectures>();
            }
        }

        //  Insert the object to Lectures table
        //  ادخال مستخدم
        public void InsertLecture(Lectures newLecture)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(newLecture);
        }

        //================================================
        // Object ارجاع بيانات سجل محاضرة واحد على شكل   
        public Lectures GetLecture(string code)
        {
            var db = new SQLiteConnection(dbPath);
            return db.Table<Lectures>().Where(i => i.CourseCode == code).FirstOrDefault();
        }

        //================================================
        // List of Lectures ارجاع بيانات مقرر جميع سجلات الشعب للمقرر الواحد على شكل   
        public List<Lectures> GetAllCodes(string courseName)
        {
            var db = new SQLiteConnection(dbPath);   
            return  db.Table<Lectures>().Where(i => i.CourseName == courseName).ToList();
        }

        //================================================
        // List of Lectures ارجاع بيانات جميع المقرارات مع جميع سجلات الشعب على شكل   

        public List<Lectures> GetAllCourses()
        {
            var db = new SQLiteConnection(dbPath);   
            return db.Table<Lectures>().ToList();                       
        }
        //=================================
        // تحديث مستخدم
        public void UpdateLecture(Lectures lecture)
        {
            var db = new SQLiteConnection(dbPath);
            db.Update(lecture);
        }

        //=================================
        // تحديث مستخدم
        public void DeleteLecture(Lectures lecture)
        {
            var db = new SQLiteConnection(dbPath);
            db.Delete(lecture);
        }                         
    }
}