using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectWebApi.DTO
{
    public class QuestionDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessionId { get; set; }
        public int UserId { get; set; }
    }
}
