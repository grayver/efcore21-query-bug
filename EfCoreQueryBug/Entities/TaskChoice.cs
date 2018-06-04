namespace EfCoreQueryBug.Entities
{
    public class TaskChoice
    {
        public int Id { get; set; }

        public int QuestTaskId { get; set; }

        public int? Index { get; set; }

        public bool IsCorrect { get; set; }

        public string Text { get; set; }

        public string ImageMime { get; set; }

        public string ImageFilename { get; set; }

        public decimal? CenterX { get; set; }

        public decimal? CenterY { get; set; }

        public decimal? Radius { get; set; }
    }
}
