using System.ComponentModel.DataAnnotations;

namespace EfCoreQueryBug.Entities
{
    public class WhatsNextTask : TaskWithChoices
    {
        [MaxLength(256)]
        public string Subject { get; set; }
    }
}
