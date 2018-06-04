namespace EfCoreQueryBug.Entities
{
    public class HiddenAreaTask : TaskWithChoices
    {
        public decimal CenterX { get; set; }

        public decimal CenterY { get; set; }

        public decimal Radius { get; set; }
    }
}
