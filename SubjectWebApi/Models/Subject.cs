namespace SubjectWebApi.Models
{
    public class Subject
    {
        public int Id { get; set; } 
        public String SubJectId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int TeacherId { get;set; }
    }
}
