namespace EfCoreQueryBug.Entities
{
    public abstract class QuestTask
    {
        public int Id { get; set; }

        public int QuestId { get; set; }

        public decimal StartTime { get; set; }

        public decimal Duration { get; set; }

        public decimal Reward { get; set; }


        public Quest Quest { get; set; }
    }
}
