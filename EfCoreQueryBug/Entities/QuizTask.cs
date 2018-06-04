using System.ComponentModel.DataAnnotations;

namespace EfCoreQueryBug.Entities
{
    public class QuizTask : TaskWithChoices
    {
        [Required]
        [MaxLength(256)]
        public string Subject { get; set; }
    }
}
