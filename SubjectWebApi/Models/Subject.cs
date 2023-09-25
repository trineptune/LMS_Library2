using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubjectWebApi.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public String SubJectId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public String TeacherName { get;set; }
        public bool star {  get; set; }
        public ICollection<Lesson> Lession { get; set;}
    }
}
