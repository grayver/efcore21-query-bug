using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreQueryBug.Entities
{
    public class Quest
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public decimal StartTime { get; set; }

        public decimal Duration { get; set; }

        public decimal? Difficulty { get; set; }

        public bool IsPublished { get; set; }


        public ICollection<QuestTask> Tasks { get; set; }
    }
}
