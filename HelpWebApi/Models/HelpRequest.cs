using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelpWebApi.Models
{
    public class HelpRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Message { get; set; }
        public int UserId {  get; set; }
    }
}
