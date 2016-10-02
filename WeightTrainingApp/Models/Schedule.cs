using System.Collections.Generic;

namespace WeightTrainingApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ScheduledExercise> ScheduledExercises { get; set; } = new HashSet<ScheduledExercise>();
        public bool IsDeleted { get; set; }
    }
}
