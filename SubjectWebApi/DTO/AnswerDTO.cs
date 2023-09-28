using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectWebApi.DTO
{
    public class AnswerDTO
    {
        public string AnswerDescription { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
