namespace SubjectWebApi.Models
{
    public class LessonFile
    {
        public int Id { get; set; } 
        public int LessionId { get; set; }
        public String FilePath { get; set; }
    }
}
