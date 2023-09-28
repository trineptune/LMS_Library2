using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubjectWebApi.Models
{
    public class Lession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LessonName { get; set; }
        public int subjectId {  get; set; }
        public virtual Subject Subject { get; set; }
        public string Description { get; set; }
        public bool Approve { get; set; }
        public ICollection<ResourcesFile> LessonsFile { get; set; }
        public ICollection<Question> Question { get; set; }
    }
}
