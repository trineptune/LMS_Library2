using SubjectWebApi.Models;

namespace SubjectWebApi.DTO
{
    public class LessionDTO
    {
        public string LessonName { get; set; }
        public int subjectId { get; set; }
        public string Description { get; set; }
        public bool Approve { get; set; }
    }
}
