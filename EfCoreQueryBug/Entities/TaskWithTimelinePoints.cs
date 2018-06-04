using System.Collections.Generic;

namespace EfCoreQueryBug.Entities
{
    public abstract class TaskWithTimelinePoints : QuestTask
    {
        public ICollection<TimelinePoint> TimelinePoints { get; set; }
    }
}
