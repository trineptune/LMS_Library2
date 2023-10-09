using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileWebApi.Models
{
    public class ResoureFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public double FileLength { get; set; }
        public int UserId { get; set; }
        public string FilePath {  get; set; }
        public DateTime LastUpdated { get; set; }
        public int SubjectId { get; set; }

    }
}
