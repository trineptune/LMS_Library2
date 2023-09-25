using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubjectWebApi.Models
{
    public class LessonFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int LessionId { get; set; }
        public String FilePath { get; set; }
        public bool Approve { get; set; }
        public virtual Lesson lession { get; set; }
    }
}
