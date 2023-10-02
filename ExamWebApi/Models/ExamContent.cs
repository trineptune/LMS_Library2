namespace ExamWebApi.Models
{
    public class ExamContent
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ExamId {  get; set; }
        public virtual Exam Exam { get; set; }
        public List<ExamAnswer> ExamAnswer { get; set; }
    }
}
