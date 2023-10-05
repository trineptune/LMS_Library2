using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamWebApi.Models
{
    public class ExamContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public int ExamId {  get; set; }
        public string Difficulty { get; set; }

        public virtual Exam Exam { get; set; }
        public List<ExamAnswer> ExamAnswer { get; set; }
    }
}
