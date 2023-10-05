using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamWebApi.Models
{
    public class EssayAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EssayId {  get; set; }
        public string? Answer {  get; set; }
        public int UserId {  get; set; }
        public virtual EssayExam? EssayExam { get; set; }

    }
}
