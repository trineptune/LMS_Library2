using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectWebApi.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }
        public int userId {  get; set; }
        public int Subjectid {  get; set; }
        public virtual Subject Subject { get; set; }

    }
}
