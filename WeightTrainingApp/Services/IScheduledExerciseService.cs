using WeightTrainingApp.Dtos;
using System.Collections.Generic;

namespace WeightTrainingApp.Services
{
    public interface IScheduledExerciseService
    {
        ScheduledExerciseAddOrUpdateResponseDto AddOrUpdate(ScheduledExerciseAddOrUpdateRequestDto request);
        ICollection<ScheduledExerciseDto> Get();
        ScheduledExerciseDto GetById(int id);
        dynamic Remove(int id);
    }
}
