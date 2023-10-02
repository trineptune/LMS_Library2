namespace ExamWebApi.Models
{
    public class ExamAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        
        public virtual ExamContent ExamContent { get; set; }
    }
}
