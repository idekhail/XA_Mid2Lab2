using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XA_Mid2Lab2
{
    [Activity(Label = "AddCourseActivity")]
    public class AddCourseActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_addcouse);


            var Code = FindViewById<EditText>(Resource.Id.Code);
            var Course = FindViewById<EditText>(Resource.Id.Course);
            var Teacher = FindViewById<EditText>(Resource.Id.Teacher);

            var AddCouse = FindViewById<Button>(Resource.Id.AddCouse);
            var Cancel = FindViewById<Button>(Resource.Id.Cancel);

            AddCouse.Click += delegate
            {
                if (Code.Text != "" && Course.Text != "" && Teacher.Text != "")
                {
                    var sq = new SQLiteDB();
                    var lecture = sq.GetLecture(Code.Text);

                    if (lecture == null)
                    {
                        var newLecture = new Lectures()
                        {
                            CourseCode = Code.Text,
                            CourseName = Course.Text,
                            TeacherName = Teacher.Text,
                        };

                        sq.InsertLecture(newLecture);
                        Intent i = new Intent(this, typeof(MainActivity));
                        StartActivity(i);
                    }
                    else
                    {
                        Toast.MakeText(this, " Code is found", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, " Code , Course or Teacher failds are empty", ToastLength.Short).Show();
                }
            };


            Cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

        }
    }
}