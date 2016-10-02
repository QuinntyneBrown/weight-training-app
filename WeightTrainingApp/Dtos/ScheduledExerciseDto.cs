namespace WeightTrainingApp.Dtos
{
    public class ScheduledExerciseDto
    {
        public ScheduledExerciseDto(WeightTrainingApp.Models.ScheduledExercise entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public ScheduledExerciseDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
