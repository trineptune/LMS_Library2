namespace ExamWebApi.DTO
{
    public class ExamDTO
    {
        public string Title { get; set; }
        public int SubjectId { get; set; }
        public string type { get; set; }
        public int time { get; set; }
        public int UserId { get; set; }
        public bool approve { get; set; }
    }
}
