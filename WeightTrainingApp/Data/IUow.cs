using WeightTrainingApp.Models;

namespace WeightTrainingApp.Data
{
    public interface IUow
    {
        IRepository<Exercise> Exercises { get; }
        IRepository<Schedule> Schedules { get; }
        IRepository<ScheduledExercise> ScheduledExercises { get; }
        void SaveChanges();
    }
}
