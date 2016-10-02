namespace WeightTrainingApp.Dtos
{
    public class ScheduleDto
    {
        public ScheduleDto(WeightTrainingApp.Models.Schedule entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public ScheduleDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
