namespace ExamWebApi.DTO
{
    public class ExamAnswerDTO
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
