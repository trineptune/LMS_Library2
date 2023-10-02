namespace ExamWebApi.Models
{
    public class Exam
    {
        public int Id { get; set; } 
        public string Title {  get; set; }
        public int SubjectId {  get; set; }
        public string type {  get; set; }
        public int time {  get; set; }
        public int UserId { get; set; }
        public bool approve {  get; set; }

    }
}
