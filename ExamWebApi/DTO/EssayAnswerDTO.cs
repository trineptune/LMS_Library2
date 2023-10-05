namespace ExamWebApi.DTO
{
    public class EssayAnswerDTO
    {
        public int EssayId { get; set; }
        public string? Answer { get; set; }
        public int UserId { get; set; }
    }
}
