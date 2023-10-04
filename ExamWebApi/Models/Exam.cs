using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamWebApi.Models
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Title {  get; set; }
        public int SubjectId {  get; set; }
        public string type {  get; set; }
        public int time {  get; set; }
        public int UserId { get; set; }
        public bool approve {  get; set; }
        public ICollection<EssayExam> EssayExam { get; set; }
        public ICollection<ExamContent> ExamContent { get; set; }

    }
}
