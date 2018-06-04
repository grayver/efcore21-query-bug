namespace EfCoreQueryBug.Entities
{
    public class TimelinePoint
    {
        public int Id { get; set; }

        public int QuestTaskId { get; set; }

        public decimal Position { get; set; }
    }
}
