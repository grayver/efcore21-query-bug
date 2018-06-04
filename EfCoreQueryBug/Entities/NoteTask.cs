using System.ComponentModel.DataAnnotations;

namespace EfCoreQueryBug.Entities
{
    public class NoteTask : TaskWithTimelinePoints
    {
        [Required]
        [MaxLength(256)]
        public string Subject { get; set; }
    }
}
