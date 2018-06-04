using EfCoreQueryBug.Entities;
using EfCoreQueryBug.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EfCoreQueryBug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private EfCoreQueryBugContext _context;

        public ValuesController(EfCoreQueryBugContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var quizTask = new QuizTask
            {
                StartTime = 45m,
                Duration = 10m,
                Subject = "Is there any life on the Mars?",
                Choices = new List<TaskChoice>()
            };
            quizTask.Choices.Add(new TaskChoice { Text = "Yes", IsCorrect = false });
            quizTask.Choices.Add(new TaskChoice { Text = "No", IsCorrect = false });
            quizTask.Choices.Add(new TaskChoice { Text = "May be", IsCorrect = false });
            quizTask.Choices.Add(new TaskChoice { Text = "I don't know", IsCorrect = false });

            var hiddenAreaTask = new HiddenAreaTask
            {
                StartTime = 61m,
                Duration = 10m,
                CenterX = 0.5m,
                CenterY = 0.5m,
                Radius = 0.2m,
                Choices = new List<TaskChoice>()
            };
            hiddenAreaTask.Choices.Add(new TaskChoice { CenterX = 0.2m, CenterY = 0.2m, Radius = 0.1m, ImageFilename = "choice1", ImageMime = "image/jpeg", IsCorrect = false });
            hiddenAreaTask.Choices.Add(new TaskChoice { CenterX = 0.3m, CenterY = 0.3m, Radius = 0.1m, ImageFilename = "choice2", ImageMime = "image/jpeg", IsCorrect = true });
            hiddenAreaTask.Choices.Add(new TaskChoice { CenterX = 0.4m, CenterY = 0.4m, Radius = 0.1m, ImageFilename = "choice3", ImageMime = "image/jpeg", IsCorrect = false });

            var hearTask = new HearTask
            {
                StartTime = 50m,
                Duration = 65m,
                Subject = "Kitchen",
                TimelinePoints = new List<TimelinePoint>()
            };
            hearTask.TimelinePoints.Add(new TimelinePoint { Position = 55m });
            hearTask.TimelinePoints.Add(new TimelinePoint { Position = 60m });

            var quest = new Quest
            {
                Name = "Cool video quest",
                StartTime = 35.6m,
                Duration = 103.5m,
                IsPublished = false,
                Tasks = new List<QuestTask>()
            };
            quest.Tasks.Add(quizTask);
            quest.Tasks.Add(hiddenAreaTask);
            quest.Tasks.Add(hearTask);

            _context.Quests.Add(quest);
            await _context.SaveChangesAsync();

            return Ok("Quest was successfully added");
        }
    }
}
