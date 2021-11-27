using SQLite;
namespace XA_Mid2Lab2
{
    // Lectures Teble
    [Table("Lectures")]
    public class Lectures
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string CourseCode { get; set; }
        [MaxLength(8)]
        public string CourseName { get; set; }
        [MaxLength(10)]
        public string TeacherName { get; set; }

    }
}