using System;
using System.Collections.Generic;
using WeightTrainingApp.Dtos;
using WeightTrainingApp.Data;
using System.Linq;

namespace WeightTrainingApp.Services
{
    public class ExerciseService : IExerciseService
    {
        public ExerciseService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Exercises;
            _cache = cacheProvider.GetCache();
        }

        public ExerciseAddOrUpdateResponseDto AddOrUpdate(ExerciseAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Exercise());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new ExerciseAddOrUpdateResponseDto(entity);
        }

        public ICollection<ExerciseDto> Get()
        {
            ICollection<ExerciseDto> response = new HashSet<ExerciseDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new ExerciseDto(entity)); }
            return response;
        }

        public ExerciseDto GetById(int id)
        {
            return new ExerciseDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.Exercise> _repository;
        protected readonly ICache _cache;
    }
}
