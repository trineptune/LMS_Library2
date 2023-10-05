using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ExamWebApi.Models
{
    public class EssayExam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ExamId {  get; set; }
        public string Titlte {  get; set; }
        public virtual Exam Exam { get; set; }
        public string Difficulty {  get; set; }
        public virtual ICollection<EssayAnswer> EssayAnswer { get; set; }
    }
}
