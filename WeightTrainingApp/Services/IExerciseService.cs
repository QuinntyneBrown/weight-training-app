using WeightTrainingApp.Dtos;
using System.Collections.Generic;

namespace WeightTrainingApp.Services
{
    public interface IExerciseService
    {
        ExerciseAddOrUpdateResponseDto AddOrUpdate(ExerciseAddOrUpdateRequestDto request);
        ICollection<ExerciseDto> Get();
        ExerciseDto GetById(int id);
        dynamic Remove(int id);
    }
}
