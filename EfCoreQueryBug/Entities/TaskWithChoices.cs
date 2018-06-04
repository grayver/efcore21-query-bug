using System.Collections.Generic;

namespace EfCoreQueryBug.Entities
{
    public abstract class TaskWithChoices : QuestTask
    {
        public ICollection<TaskChoice> Choices { get; set; }
    }
}
