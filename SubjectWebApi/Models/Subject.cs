using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubjectWebApi.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int UserId {  get; set; }
        public bool star {  get; set; }
        public ICollection<Lession> Lession { get; set;}
        public ICollection<SubjectNotification> SubjectNotification { get; set;}
        public ICollection<Class> Class { get; set;}    
    }
}
