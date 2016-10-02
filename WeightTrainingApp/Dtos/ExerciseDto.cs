namespace WeightTrainingApp.Dtos
{
    public class ExerciseDto
    {
        public ExerciseDto()
        {

        }

        public ExerciseDto(Models.Exercise entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
