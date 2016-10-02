using WeightTrainingApp.Dtos;
using System.Collections.Generic;

namespace WeightTrainingApp.Services
{
    public interface IScheduleService
    {
        ScheduleAddOrUpdateResponseDto AddOrUpdate(ScheduleAddOrUpdateRequestDto request);
        ICollection<ScheduleDto> Get();
        ScheduleDto GetById(int id);
        dynamic Remove(int id);
    }
}
