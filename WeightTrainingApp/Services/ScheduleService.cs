using System;
using System.Collections.Generic;
using WeightTrainingApp.Data;
using WeightTrainingApp.Dtos;
using System.Data.Entity;
using System.Linq;
using WeightTrainingApp.Models;

namespace WeightTrainingApp.Services
{
    public class ScheduleService : IScheduleService
    {
        public ScheduleService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Schedules;
            _cache = cacheProvider.GetCache();
        }

        public ScheduleAddOrUpdateResponseDto AddOrUpdate(ScheduleAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Schedule());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new ScheduleAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<ScheduleDto> Get()
        {
            ICollection<ScheduleDto> response = new HashSet<ScheduleDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ScheduleDto(entity)); }    
            return response;
        }


        public ScheduleDto GetById(int id)
        {
            return new ScheduleDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Schedule> _repository;
        protected readonly ICache _cache;
    }
}
