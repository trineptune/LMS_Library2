using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubjectWebApi.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string AnswerDescription { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public virtual Question Question { get; set; }
    }
}
