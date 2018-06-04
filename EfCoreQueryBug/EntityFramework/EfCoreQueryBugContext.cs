using EfCoreQueryBug.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreQueryBug.EntityFramework
{
    public class EfCoreQueryBugContext : DbContext
    {
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestTask> QuestTasks { get; set; }
        public DbSet<QuizTask> QuestQuizTasks { get; set; }
        public DbSet<WhatsNextTask> QuestWhatsNextTasks { get; set; }
        public DbSet<HiddenAreaTask> QuestHiddenAreaTasks { get; set; }
        public DbSet<NoteTask> QuestNoteTasks { get; set; }
        public DbSet<HearTask> QuestHearTasks { get; set; }
        public DbSet<TaskChoice> QuestTaskChoices { get; set; }
        public DbSet<TimelinePoint> QuestTimelinePoints { get; set; }

        public EfCoreQueryBugContext(DbContextOptions<EfCoreQueryBugContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quest>()
                .ToTable("Quests");

            modelBuilder.Entity<QuestTask>()
                .ToTable("QuestTasks");

            modelBuilder.Entity<QuestTask>()
                .HasDiscriminator<string>("Type")
                .HasValue<QuizTask>("quiz")
                .HasValue<WhatsNextTask>("whats-next")
                .HasValue<HiddenAreaTask>("hidden-area")
                .HasValue<NoteTask>("note")
                .HasValue<HearTask>("hear");

            modelBuilder.Entity<QuizTask>()
                .HasMany(qt => qt.Choices)
                .WithOne()
                .HasForeignKey(tc => tc.QuestTaskId);

            modelBuilder.Entity<QuizTask>()
                .Property(qt => qt.Subject)
                .HasColumnName("Subject");

            modelBuilder.Entity<WhatsNextTask>()
                .HasMany(wnt => wnt.Choices)
                .WithOne()
                .HasForeignKey(tc => tc.QuestTaskId);

            modelBuilder.Entity<WhatsNextTask>()
                .Property(wnt => wnt.Subject)
                .HasColumnName("Subject");

            modelBuilder.Entity<HiddenAreaTask>()
                .HasMany(hat => hat.Choices)
                .WithOne()
                .HasForeignKey(tc => tc.QuestTaskId);

            modelBuilder.Entity<NoteTask>()
                .HasMany(nt => nt.TimelinePoints)
                .WithOne()
                .HasForeignKey(tp => tp.QuestTaskId);

            modelBuilder.Entity<NoteTask>()
                .Property(nt => nt.Subject)
                .HasColumnName("Subject");

            modelBuilder.Entity<HearTask>()
                .HasMany(ht => ht.TimelinePoints)
                .WithOne()
                .HasForeignKey(tp => tp.QuestTaskId);

            modelBuilder.Entity<HearTask>()
                .Property(ht => ht.Subject)
                .HasColumnName("Subject");

            modelBuilder.Entity<TaskChoice>()
                .ToTable("QuestTaskChoices");

            modelBuilder.Entity<TimelinePoint>()
                .ToTable("QuestTimelinePoints");
        }
    }
}
