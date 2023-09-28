using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SubjectWebApi.Models
{
    public class ResourcesFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int LessionId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool Approve { get; set; }
        public int UserId { get; set; }
        public virtual Lession lession { get; set; }
    }
}
