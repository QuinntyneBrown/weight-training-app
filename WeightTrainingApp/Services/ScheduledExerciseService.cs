using System;
using System.Collections.Generic;
using WeightTrainingApp.Data;
using WeightTrainingApp.Dtos;
using System.Data.Entity;
using System.Linq;
using WeightTrainingApp.Models;

namespace WeightTrainingApp.Services
{
    public class ScheduledExerciseService : IScheduledExerciseService
    {
        public ScheduledExerciseService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.ScheduledExercises;
            _cache = cacheProvider.GetCache();
        }

        public ScheduledExerciseAddOrUpdateResponseDto AddOrUpdate(ScheduledExerciseAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new ScheduledExercise());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new ScheduledExerciseAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<ScheduledExerciseDto> Get()
        {
            ICollection<ScheduledExerciseDto> response = new HashSet<ScheduledExerciseDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ScheduledExerciseDto(entity)); }    
            return response;
        }


        public ScheduledExerciseDto GetById(int id)
        {
            return new ScheduledExerciseDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<ScheduledExercise> _repository;
        protected readonly ICache _cache;
    }
}
