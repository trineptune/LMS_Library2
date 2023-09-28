using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubjectWebApi.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessionId { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId {  get; set; }
        public virtual Lession lession { get; set; } 
        public ICollection<Answer> Answers { get; set; }
    }
}
